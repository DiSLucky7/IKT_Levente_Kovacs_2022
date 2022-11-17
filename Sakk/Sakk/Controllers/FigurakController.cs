using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Sakk.Models;
using System.Collections.Generic;

namespace Sakk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FigurakController:ControllerBase
    {
        [HttpGet]
        [Route("GetFigurak")]
        public IActionResult GetFigurak()
        {
            //List<Figurak> list = new List<Figurak>();
            using (var context=new sakkContext())
            {
                try
                {
                    //return context.Figuraks.ToList();
                    return StatusCode(200, context.Figuraks.ToList());
                }
                catch (Exception ex)
                {
                    //Figurak figura = new Figurak();
                    //figura.Megnevezes = "Az adatbázis nem elérhető. " + ex.Message;
                    //list.Add(figura);
                    //return list;
                    return BadRequest(ex);
                }
            }
        }


        [HttpPost]
        [Route("PostFigurak")]
        public IActionResult PostFigurak(Figurak figura)
        {
            using (var context = new sakkContext())
            {
                try
                {
                    context.Figuraks.Add(figura);
                    context.SaveChanges();
                    return StatusCode(201, "A figura hozzáadása sikeresen megtörtént. " + context.Figuraks.ToList());
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
        }


        [HttpPut]
        [Route("PutFigurak")]
        public IActionResult PutFigurak(Figurak figura)
        {
            using (var context = new sakkContext())
            {
                try
                {
                    context.Figuraks.Update(figura);
                    context.SaveChanges();
                    return StatusCode(290, "A figura adatainak a módosítása sikeresen megtörtént. " + context.Figuraks.ToList());
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
        }


        [HttpDelete]
        [Route("DeleteFigurak")]
        public IActionResult DeleteFigurak(int Id)
        {
            using (var context = new sakkContext())
            {
                try
                {
                    Figurak figura = new Figurak();
                    figura.Id = Id;
                    context.Figuraks.Remove(figura);
                    context.SaveChanges();
                    return StatusCode(201, "A figura adatainak a törlése sikeresen megtörtént." + context.Figuraks.ToList());
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
        }
    }
}
