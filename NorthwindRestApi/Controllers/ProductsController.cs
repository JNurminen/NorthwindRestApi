using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindRestApi.Models;

namespace NorthwindRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // Luodaan tietokantayhteys
        NorthwindContext db = new NorthwindContext();

        // Hae kaikki tuotteet
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var tuotteet = db.Products.ToList();
            return Ok(tuotteet);
        }
    }
}
