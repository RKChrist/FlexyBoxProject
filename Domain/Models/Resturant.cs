using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Resturant
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public bool Open { get; set; } = false;

        public string Address { get; set; } = string.Empty;

        public string PostCode { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string TelefonNumber { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public List<Images>? Images { get; set; }

        public List<Openings>? Openings{ get; set; }
    }
}
