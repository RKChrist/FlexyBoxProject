using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class ResturantDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PostCode { get; set; } = string.Empty;

        public bool Liked { get; set; } = false;

        public bool Open { get; set; } = false;

        public string Address { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string TelefonNumber { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public int SliderInterval { get; } = 3000;

        public List<ImageDTO> Images { get; set; }

        public List<OpeningsDTO>? Openings { get; set; }
    }
}
