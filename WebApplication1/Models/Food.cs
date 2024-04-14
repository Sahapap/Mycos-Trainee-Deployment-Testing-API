using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models
{
    public class Food
    {
        [FromQuery]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
