using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Verseny.Models;

namespace Verseny.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FelhasznalokController : ControllerBase
    {
        [HttpGet("{uId")]
        public IActionResult Get(string uId)
        {
            List<Felhasznalok> felhasznaloks = new List<Felhasznalok>();
            return Ok(uId);

        }
    }
}
