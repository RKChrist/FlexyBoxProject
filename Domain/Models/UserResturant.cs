using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserResturant
    {
        public string UserIdentification { get; set; }

        public int ResturantId { get; set; }

        public bool Toggled { get;set; }
    }
}
