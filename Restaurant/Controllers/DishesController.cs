using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Dishes.Commands.CreateDish;
using Restaurant.Application.Dishes.Commands.DeleteDishes;
using Restaurant.Application.Dishes.Commands.UpdateDish;
using Restaurant.Application.Dishes.Dtos;
using Restaurant.Application.Dishes.Queries;

namespace Restaurant.API.Controllers
{
    [Route("api/restaurants/{restaurantId}/dishes")]
    [ApiController]
    [Authorize]

    public class DishesController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateDish([FromRoute] int restaurantId, [FromBody] CreateDishCommand command)
        {
            command.RestaurantId = restaurantId;
            await mediator.Send(command);
            return Created();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<DishDto>>> GetAllForRestaurant([FromRoute] int restaurantId)
        {
            var dishes = await mediator.Send(new GetDishesForRestaurantQuery(restaurantId));
            return Ok(dishes);
        }

        [HttpGet("{dishId}")]
        public async Task<ActionResult<DishDto>> GetByIdForRestaurant([FromRoute] int restaurantId, [FromRoute] int dishId)
        {
            var dishes = await mediator.Send(new GetDisheByIdForRestaurantQuery(restaurantId, dishId));
            return Ok(dishes);
        }

        [HttpPut("{dishId}")]
        public async Task<IActionResult> UpdateDish([FromRoute] int restaurantId, [FromRoute] int dishId, [FromBody] UpdateDishCommand command)
        {
            command.Id = dishId;
            command.RestaurantId = restaurantId;
            await mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{dishId}")]
        public async Task<ActionResult<DishDto>> DeleteByIdForRestaurant([FromRoute] int restaurantId, [FromRoute] int dishId)
        {
            await mediator.Send(new DeleteDishByIdForRestaurantCommand(restaurantId, dishId));
            return NoContent();
        }
    }
}
