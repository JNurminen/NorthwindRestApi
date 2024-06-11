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
            var tyontekijat = db.Employees.ToList();
            return Ok(tyontekijat);
        }
    }
}
