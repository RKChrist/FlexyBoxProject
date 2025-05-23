using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("Openings")]
    public class Openings
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool Toggled { get; set; }

        public int ResturantId { get; set; }

        public List<DaysOpen>? Days { get; set; }
    }
}
