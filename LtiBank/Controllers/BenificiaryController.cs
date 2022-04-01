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
    public class BenificiaryController : ControllerBase
    {
        private readonly BankingProjectContext db;

        public BenificiaryController(BankingProjectContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Get()
        {

            var cat = db.Benificiaries.ToList();
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
        public IActionResult AddOnlineDetails(Benificiary benificiary)
        {
            try
            {
                if (benificiary == null)
                {
                    return BadRequest("Benificiary is null");
                }
                else
                {
                    db.Benificiaries.Add(benificiary);
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

                var benificiary = db.Benificiaries.Find(id);
                if (benificiary != null)
                {
                    db.Benificiaries.Remove(benificiary);
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
        public IActionResult Edit(int? id, [FromBody] Benificiary benificiary)
        {
            try
            {
                if (id != benificiary.Benaccountno)
                {
                    return BadRequest();
                }
                else
                {
                    db.Entry(benificiary).State = EntityState.Modified;
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



