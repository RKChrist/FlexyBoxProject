using MediatR;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Resturant.GetAllResturants
{
    public class GetAllResturantsCommand : IRequest<List<ResturantDTO>>
    {
    }
}
