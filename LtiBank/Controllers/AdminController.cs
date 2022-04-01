using LtiBank.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LtiBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly BankingProjectContext db;

        public AdminController(BankingProjectContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Get()
        {

            var cat = db.Admins.ToList();
            if (cat != null)
            {
                return Ok(cat);
            }
            else
            {
                return NotFound("data not found");
            }

        }
        [HttpPost]
        public IActionResult AddOnlineDetails(Admin admin)
        {
            try
            {
                if (admin == null)
                {
                    return BadRequest("Admininfo is null");
                }
                else
                {
                    db.Admins.Add(admin);
                    db.SaveChanges();
                    return Ok("Record Added!!");
                }
            }


            catch (Exception e)
            {
                return Ok("Some Error Occured!!!");
            }


        }


        [HttpDelete("{id}")]
        public IActionResult Deletebyid(int? id)
        {
            try
            {

                var admin = db.Admins.Find(id);
                if (admin != null)
                {
                    db.Admins.Remove(admin);
                    db.SaveChanges();
                    return Ok("Record Deleted!!!");
                }
                else
                {
                    return NotFound("No Data Found!!");
                }

            }
            catch (Exception e)
            {
                return Ok("Please try Again!!");
            }
        }
        [HttpPut("{id}")]
        public IActionResult Edit(string id, [FromBody] Admin admin)
        {
            try
            {
                if (id != admin.Adminid)
                {
                    return BadRequest();
                }
                else
                {
                    db.Entry(admin).State = EntityState.Modified;
                    db.SaveChanges();
                    return Ok("record updated!!!");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}
