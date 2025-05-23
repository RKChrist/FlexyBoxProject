using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("Days")]
    public class DaysOpen
    {

        public int Id { get; set; }

        [Column("OpeningsId")]
        public int OpeningsId { get; set; }

        public Days Days { get; set; }

        public TimeOnly StartTimeSlot { get; set; }

        public TimeOnly EndTimeSlot { get; set; }
    }
}
