using Application.Handlers.Resturant.GetAllResturants;
using Application.Handlers.Resturant.GetSingleResturant;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlexyBoxProject.Controllers
{
    [Route("api/[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly IMediator mediator;

        public RestaurantController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GET()
        {
            var result = await mediator.Send(new GetAllResturantsCommand());

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await mediator.Send(new GetSingleResturantCommand() { Id = id});

            return Ok(result);
        }

    }
}
