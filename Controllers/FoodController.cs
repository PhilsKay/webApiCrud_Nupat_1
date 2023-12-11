using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using webApi_Nupat_1.Data;
using webApi_Nupat_1.Model;

namespace webApi_Nupat_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly DataContext _context;

        public FoodController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("post")]
        public IActionResult CreateFood([FromBody]Food addFood)
        {
            var food = _context.Foods.Add(addFood);
            _context.SaveChanges();

            return Ok(food);
        }

        //food/10
        [HttpGet("{id}")]
        public IActionResult GetFoodById(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            Food food = _context.Foods.Find(id);
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
            Food food = _context.Foods.Where(x => x.Name == name).FirstOrDefault();
            if (food == null)
            {
                return NotFound("ddd");
            }
            return Ok(food);
        }

        [HttpGet("all")]
        public IActionResult GetFoodByName()
        {
            List<Food> foods = _context.Foods.ToList();
            return Ok(foods);
        }

        [HttpDelete("{id}")]
        public IActionResult GetFoodByName(int id)
        {
            Food food = _context.Foods.Find(id);
            if (food == null)
            {
                return NotFound("ddd");
            }
            _context.Foods.Remove(food);
            _context.SaveChanges();

            return Ok("successful");
        }
    }
}
