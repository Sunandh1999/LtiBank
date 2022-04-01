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
    public class RegisterController : ControllerBase
    {
        private readonly BankingProjectContext db;

        public RegisterController(BankingProjectContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Get()
        {

            var cat = db.Registers.ToList();
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
        public IActionResult AddOnlineDetails(Register register)
        {
            try
            {
                if (register == null)
                {
                    return BadRequest("register is null");
                }
                else
                {
                    db.Registers.Add(register);
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

                var register = db.Registers.Find(id);
                if (register != null)
                {
                    db.Registers.Remove(register);
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
        public IActionResult Edit(int? id, [FromBody] Register register)
        {
            try
            {
                if (id != register.Rid)
                {
                    return BadRequest();
                }
                else
                {
                    db.Entry(register).State = EntityState.Modified;
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


