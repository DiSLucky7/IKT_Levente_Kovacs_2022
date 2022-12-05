using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AzureTest.Models;

namespace AzureTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SzendvicsController : ControllerBase
    {
        public static List<Szendvics> Szendvicsek = new List<Szendvics>();


        [HttpGet]
        public IActionResult GetSzendvicsek()
        {
            Szendvics szendvics1 = new Szendvics();
            szendvics1.ID = 1;
            szendvics1.Nev = "Tojásos";
            szendvics1.Felvagott = "túrista";
            szendvics1.Vaj = "tea";
            szendvics1.Zoldseg = "paradicsom";

            Szendvics szendvics2 = new Szendvics();
            szendvics2.ID = 2;
            szendvics2.Nev = "Párizsis";
            szendvics2.Felvagott = "Zala felvágott";
            szendvics2.Vaj = "rama";
            szendvics2.Zoldseg = "paprika";

            Szendvicsek.Add(szendvics1);
            Szendvicsek.Add(szendvics2);

            return Ok(Szendvicsek);
        }


        [HttpPost]
        public IActionResult PostSzendvics()
        {
            Szendvics szendvics = new Szendvics();
            szendvics.ID = 3;
            szendvics.Nev = "Post teszt szendvics";
            szendvics.Felvagott = "téliszalámi";
            szendvics.Vaj = "bords eva";
            szendvics.Zoldseg = "uborka";
            try
            {
                Szendvicsek.Add(szendvics);
                return Ok("A szendvics hozzáaadása megtörtént.");
            }
            catch (Exception ex)
            {
                return BadRequest("A szendvics hozzáaadása sikertelen " + ex.Message);
            }
        }


        [HttpPut]
        public IActionResult PutSzendvics()
        {
            try
            {
                Szendvicsek[0].Nev = "Gőzöm sincs";
                return Ok("A szendvics módosítása megtörtént.");
            }
            catch (Exception ex)
            {
                return BadRequest("A szendvics módosítása sikertelen. " + ex.Message);
            }
        }


        [HttpDelete]
        public IActionResult DeleteSzendvics()
        {
            try
            {
                Szendvicsek.RemoveAt(0);
                return Ok("A szendvics törlése megtörtént.");
            }
            catch (Exception ex)
            {
                return BadRequest("A szendvics törlése sikertelen. " + ex.Message);
            }
        }

    }
}
