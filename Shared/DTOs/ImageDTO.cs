using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class ImageDTO
    {
        public int Id { get; set; }

        public Guid Uid { get; set; }

        public string AltText { get; set; } = string.Empty;

        public string FileName { get; set; } = string.Empty;

        public string FileType { get; set; } = string.Empty;
    }
}
