using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIMultipleAPICallsSingleMethod.Models;

namespace WebAPIMultipleAPICallsSingleMethod.Controllers
{
    public class HospitalAPIController : Controller
    {
        private HospitalContext _context;
        public HospitalAPIController(HospitalContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult DataRequests([FromBody] Request req)
        {
            switch (req.type)
            {
                case "patient":
                    if (req.action == "insert")
                    {
                        _context.patients.Add(req.pt);
                        _context.SaveChanges();
                    }
                    else if(req.action=="update")
                    {
                        _context.Entry(req.pt).State=EntityState.Modified;
                        _context.SaveChanges();
                    }
                    break;
                case "doctor":
                    if (req.action == "insert")
                    {
                        _context.doctors.Add(req.doc);
                        _context.SaveChanges();
                    }
                    else if (req.action == "update")
                    {
                        _context.Entry(req.doc).State = EntityState.Modified;
                        _context.SaveChanges();
                    }
                    break;
            }
            return Ok();
        }
    }
}
