using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodController : Controller
    {
        private readonly ILogger<FoodController> _logger;
        private readonly FoodContext _foodContext;

        public FoodController(ILogger<FoodController> logger, FoodContext foodContext)
        {
            _logger = logger;
            _foodContext = foodContext;
        }

        [HttpGet]
        public List<Food> Get()
        {
            var data = _foodContext.Foods.ToList();
            return data;
        }

        [HttpPost]
        public async Task<string> Post([FromBody]Food food)
        {
            Food NewFood = new Food() { Name = food.Name };
            _foodContext.Foods.Add(NewFood);
            await _foodContext.SaveChangesAsync();
            return "Post Food";
        }

        [HttpPut("{id:int}")]
        public async Task<string> Put(int id, [FromBody]Food food)
        {
            var f = _foodContext.Foods.FirstOrDefault(f => f.Id == id);
            if (f != null)
            {
                f.Name = food.Name;
                await _foodContext.SaveChangesAsync();
                return "Edit Complete.";
            }
            else
            {
                return $"Nofound ID = {id}";
            }
            

        }

        [HttpDelete("{id:int}")]
        public async Task<string> Delete(int id)
        {
            var f = _foodContext.Foods.FirstOrDefault(f => f.Id == id);
            if (f != null)
            {
                _foodContext.Foods.Remove(f);
                await _foodContext.SaveChangesAsync();
                return "Remove Complete.";
            }
            else
            {
                return $"Nofound ID = {id}";
            }
        }
    }
}
