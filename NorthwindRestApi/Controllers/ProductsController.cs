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
            try { 
                var tuotteet = db.Products.ToList();
                return Ok(tuotteet);
            }
            catch (Exception e)
            {
                return BadRequest("Tapahtui virhe. Lue lisää:" + e.InnerException);
            }
        }

        // Hae yksi tuote id:n perusteella
        [HttpGet("{id}")]
        public IActionResult GetOneProductById(int id)
        {
            try { 
                var tuote = db.Products.Find(id);
                if (tuote != null)
                {
                    return Ok(tuote);
                }
                else
                {
                    return NotFound($"Tuotetta id:llä {id} ei löydy.");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Tapahtui virhe. Lue lisää:" + e.InnerException);
            }
        }
    }
}
