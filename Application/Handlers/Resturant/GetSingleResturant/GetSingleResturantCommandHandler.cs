using Application.Handlers.Resturant.GetAllResturants;
using Application.Interfaces.Repositories.ResturantRepository;
using AutoMapper;
using MediatR;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Resturant.GetSingleResturant
{
    public class GetSingleResturantCommandHandler : IRequestHandler<GetSingleResturantCommand, ResturantDTO>
    {
        private readonly IResturantRepository resturantRepository;
        private readonly IMapper mapper;

        public GetSingleResturantCommandHandler(IResturantRepository resturantRepository,
                                              IMapper mapper)
        {
            this.resturantRepository = resturantRepository;
            this.mapper = mapper;
        }


        public async Task<ResturantDTO> Handle(GetSingleResturantCommand request, CancellationToken cancellationToken)
        {
            var resturants = resturantRepository.GetSingleResturantsAndTheJoins(request.Id);


            return mapper.Map<ResturantDTO>(resturants);
        }
    }
}
