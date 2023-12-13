using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using webApi_Nupat_1.Data;
using webApi_Nupat_1.IService;
using webApi_Nupat_1.Model;

namespace webApi_Nupat_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : ControllerBase
    {
        private IFood _food;
        public FoodController(IFood food)
        {
            _food = food;
        }

        [HttpPost]
        [Route("post")]
        public IActionResult CreateFood([FromBody]Food addFood)
        {
            _food.CreateFood(addFood);

            return Ok();
        }

        //food/10
        [HttpGet("{id}")]
        public IActionResult GetFoodById(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            Food food = _food.GetFoodById(id);
            if (food == null)
            {
                return NotFound("ddd");
            }
            return Ok(food);
        }
        //food?name=rice
        [HttpGet]
        public IActionResult GetFoodByName([FromQuery]string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest();
            }
            Food food = _food.GetFoodByName(name);
            if (food == null)
            {
                return NotFound("ddd");
            }
            return Ok(food);
        }

        [HttpGet("all")]
        public IActionResult GetFoods()
        {
            List<Food> foods = _food.GetFoods();
            return Ok(foods);
        }

        [HttpDelete("{id}")]
        public IActionResult DeeleteFoodById(int id)
        {
            Food food = _food.GetFoodById(id);
            if (food == null)
            {
                return NotFound("ddd");
            }
            _food.DeleteFood(food);
            return Ok("successful");
        }
    }
}
