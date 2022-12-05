using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Verseny.Models;

namespace Verseny.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult SaltRequest(string nev)
        {
            //string salt = Verseny.Program.GenerateSalt();
            using (var context = new VersenyContext())
            {
                try
                {
                    List<Felhasznalok> talalat = new List<Felhasznalok>(context.Felhasznaloks.Where(f => f.FelhasznaloNev == nev));
                    if (talalat.Count > 0)
                    {
                        //string hash = Verseny.Program
                        string[] response;
                        int elemszam = 0;
                        return Ok(talalat[0].Salt);
                    }
                    else
                    {
                        return BadRequest("Hibás felhasználónév/jelszó.");
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
                
            }
        }
    }
}
