using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindRestApi.Models;

namespace NorthwindRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // Luodaan tietokantayhteys
        NorthwindContext db = new NorthwindContext();

        // Hae kaikki asiakkaat
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            try {
                var asiakkaat = db.Customers.ToList();
                return Ok(asiakkaat);
            }
            catch (Exception e)
            {
                return BadRequest("Tapahtui virhe. Lue lisää:" + e.InnerException);
            }
        }

        // Hae yksi asiakas id:n perusteella
        [HttpGet("{id}")]
        public IActionResult GetOneCustomerById(string id)
        {
            try { 
            var asiakas = db.Customers.Find(id);
            if (asiakas != null)
            {
                return Ok(asiakas);
            }
            else
            {
                //return NotFound("Asiakasta id:llä" + id + "ei löydy."); // Toinen tapa
                return NotFound($"Asiakasta id:llä {id} ei löydy."); // string interpolation
            }
            }
            catch (Exception e)
            {
                return BadRequest("Tapahtui virhe. Lue lisää:" + e.InnerException);
            }
        }
    }
}
