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
    public class CustinfoController : ControllerBase
    {
        private readonly BankingProjectContext db;

        public CustinfoController(BankingProjectContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Get()
        {

            var cat = db.Custinfos.ToList();
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
        public IActionResult AddOnlineDetails(Custinfo custinfo)
        {
            try
            {
                if (custinfo == null)
                {
                    return BadRequest("Custinfo is null");
                }
                else
                {
                    db.Custinfos.Add(custinfo);
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

                var custinfo = db.Custinfos.Find(id);
                if (custinfo != null)
                {
                    db.Custinfos.Remove(custinfo);
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
        public IActionResult Edit(int? id, [FromBody] Custinfo custinfo)
        {
            try
            {
                if (id != custinfo.Cid)
                {
                    return BadRequest();
                }
                else
                {
                    db.Entry(custinfo).State = EntityState.Modified;
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



