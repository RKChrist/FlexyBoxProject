using Application.Interfaces.Repositories.ResturantRepository;
using AutoMapper;
using MediatR;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Resturant.GetAllResturants
{
    public class GetAllResturantsCommandHandler : IRequestHandler<GetAllResturantsCommand, List<ResturantDTO>>
    {
        private readonly IResturantRepository resturantRepository;
        private readonly IMapper mapper;

        public GetAllResturantsCommandHandler(IResturantRepository resturantRepository,
                                              IMapper mapper)
        {
            this.resturantRepository = resturantRepository;
            this.mapper = mapper;
        }

        public async Task<List<ResturantDTO>> Handle(GetAllResturantsCommand request, CancellationToken cancellationToken)
        {
            var resturants = resturantRepository.GetAllResturantsAndTheJoins().ToList();
            

            return mapper.Map<List<ResturantDTO>>(resturants);
        }
    }
}
