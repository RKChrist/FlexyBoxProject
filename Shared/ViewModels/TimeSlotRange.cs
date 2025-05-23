using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModels
{
    public class TimeSlotRange
    {
        public Days StartDay { get; set; }
        public Days EndDay { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        public bool IsSingleDay => StartDay == EndDay;
    }
}
