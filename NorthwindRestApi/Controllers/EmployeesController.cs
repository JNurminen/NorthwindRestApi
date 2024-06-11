using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindRestApi.Models;

namespace NorthwindRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        // Luodaan tietokantayhteys
        NorthwindContext db = new NorthwindContext();

        // Hae kaikki työntekijät
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try { 
                var tyontekijat = db.Employees.ToList();
                return Ok(tyontekijat);
            }
            catch (Exception e)
            {
                return BadRequest("Tapahtui virhe. Lue lisää:" + e.InnerException);
            }
        }

        // Hae yksi työntekijä id:n perusteella
        [HttpGet("{id}")]
        public IActionResult GetOneEmployeeById(int id)
        {
            try { 
                var tyontekija = db.Employees.Find(id);
                if (tyontekija != null)
                {
                    return Ok(tyontekija);
                }
                else
                {
                    return NotFound($"Työntekijää id:llä {id} ei löydy.");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Tapahtui virhe. Lue lisää:" + e.InnerException);
            }
        }
    }
}
