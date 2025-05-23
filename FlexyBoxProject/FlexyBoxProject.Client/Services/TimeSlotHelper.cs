using System;
using System.Collections.Generic;
using System.Linq;
using Shared.DTOs;
using Shared.Enums;
using Shared.ViewModels;

namespace FlexyBoxProject.Client.Services
{
    public static class TimeSlotHelper
    {
        public static IEnumerable<TimeSlotRange> GetTimeSlotRanges(IEnumerable<DaysDTO> slots)
        {
            // 1) Group slots by identical time intervals
            var byTime = slots
                .GroupBy(s => (s.StartTimeSlot, s.EndTimeSlot))
                .Select(g => new
                {
                    Start = g.Key.StartTimeSlot,
                    End = g.Key.EndTimeSlot,
                    Days = g.Select(x => x.Days)
                            .Distinct()
                            .OrderBy(d => (int)d)
                            .ToList()
                });

            var result = new List<TimeSlotRange>();

            foreach (var grp in byTime)
            {
                // 2) Separate Mon-Thu vs Fri-Sun/Holidays
                var weekday = grp.Days.Where(d => d >= Days.Monday && d <= Days.Thursday).ToList();
                var others = grp.Days.Except(weekday).ToList();

                // 3) Group consecutive weekday runs
                result.AddRange(BuildRuns(weekday, grp.Start, grp.End));

                // 4) Single-day entries for the rest
                foreach (var d in others)
                {
                    result.Add(new TimeSlotRange
                    {
                        StartDay = d,
                        EndDay = d,
                        StartTime = grp.Start,
                        EndTime = grp.End
                    });
                }
            }

            return result;
        }

        // Helper to build ranges from a sorted list of days
        private static IEnumerable<TimeSlotRange> BuildRuns(List<Days> days, TimeOnly start, TimeOnly end)
        {
            var ranges = new List<TimeSlotRange>();
            if (days == null || days.Count == 0)
                return ranges;

            // sort to be safe
            days.Sort((a, b) => ((int)a).CompareTo((int)b));

            int runStartIndex = 0;

            for (int i = 1; i <= days.Count; i++)
            {
                bool isEndOfRun = (i == days.Count) || ((int)days[i] != (int)days[i - 1] + 1);
                if (isEndOfRun)
                {
                    // from runStartIndex to i-1 is a consecutive block
                    var startDay = days[runStartIndex];
                    var endDay = days[i - 1];
                    ranges.Add(new TimeSlotRange
                    {
                        StartDay = startDay,
                        EndDay = endDay,
                        StartTime = start,
                        EndTime = end
                    });
                    runStartIndex = i;
                }
            }

            return ranges;
        }

        public static IEnumerable<TimeSlotRange> GetClosedTimeSlotRanges(IEnumerable<DaysDTO> slots)
        {
            // first, get all the open ranges
            var openRanges = GetTimeSlotRanges(slots)
                .ToList();

            var closed = new List<TimeSlotRange>();

            // for every day in the enum
            foreach (Days day in Enum.GetValues(typeof(Days)))
            {
                // pull out the portions of each open range that apply to this single day
                var todaysOpens = openRanges
                    .Where(r => r.StartDay <= day && day <= r.EndDay)
                    .Select(r => new { r.StartTime, r.EndTime })
                    .OrderBy(o => o.StartTime)
                    .ToList();

                // start at midnight
                var cursor = TimeOnly.MinValue;
                foreach (var o in todaysOpens)
                {
                    // if there's a gap between the cursor and the next open, that's closed
                    if (cursor < o.StartTime)
                    {
                        closed.Add(new TimeSlotRange
                        {
                            StartDay = day,
                            EndDay = day,
                            StartTime = cursor,
                            EndTime = o.StartTime
                        });
                    }
                    // move the cursor forward past this open
                    if (cursor < o.EndTime)
                        cursor = o.EndTime;
                }

                // finally, if there's time from the last open until end‐of‐day, that's closed too
                var endOfDay = new TimeOnly(23, 59);
                if (cursor < endOfDay)
                {
                    closed.Add(new TimeSlotRange
                    {
                        StartDay = day,
                        EndDay = day,
                        StartTime = cursor,
                        EndTime = endOfDay
                    });
                }
            }

            return closed;
        }

    }
}
