using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModels
{
    public class User : IUser
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
