using MediatR;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Resturant.GetSingleResturant
{
    public class GetSingleResturantCommand : IRequest<ResturantDTO>
    {
        public int Id { get; set; }
    }
}
