using Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class DaysDTO
    {
        public int Id { get; set; }
        public int OpeningsId { get; set; }

        public Days Days { get; set; }

        public TimeOnly StartTimeSlot { get; set; }

        public TimeOnly EndTimeSlot { get; set; }
    }
}
