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
    public class AccountController : ControllerBase
    {
        private readonly BankingProjectContext db;

        public AccountController(BankingProjectContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Get()
        {

            var cat = db.Accounts.ToList();
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
        public IActionResult AddOnlineDetails(Account account)
        {
            try
            {
                if (account == null)
                {
                    return BadRequest("Account is null");
                }
                else
                {
                    db.Accounts.Add(account);
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

                var account = db.Accounts.Find(id);
                if (account != null)
                {
                    db.Accounts.Remove(account);
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
        public IActionResult Edit(int? id, [FromBody] Account account)
        {
            try
            {
                if (id != account.Rid)
                {
                    return BadRequest();
                }
                else
                {
                    db.Entry(account).State = EntityState.Modified;
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
