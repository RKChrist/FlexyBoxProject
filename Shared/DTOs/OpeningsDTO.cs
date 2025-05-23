using Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class OpeningsDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool Toggled { get; set; }

        public int ResturantId { get; set; }

        public List<DaysDTO>? Days { get; set; }

        public List<TimeSlotRange>? timeSlotRanges { get; set; }
    }
}
