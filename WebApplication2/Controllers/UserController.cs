using DAL.Infrastructure;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace WebApplication2.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly UserDbContext _userDbContext;

        public UserController(UserDbContext dbContext)
        {
            _userDbContext = dbContext;
        }

        [HttpPost]
        public IActionResult CreateUser()
        {
            var user = new User { name = "Gentle" };
            _userDbContext.Add(user);
            _userDbContext.SaveChanges();
            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_userDbContext.Users.Include(x => x.Invoices));
        }

        [HttpPut]
        public IActionResult UpdateUser(string id)
        {
            var userDb = _userDbContext.Users.Find(id);
            if (userDb is not { } user) throw new NullReferenceException();
            _userDbContext.Entry(user).State = EntityState.Modified;
            _userDbContext.SaveChanges();
            return Ok(user);
        }

        [HttpPut("/name")]
        public IActionResult UpdateNameUser(string id, string name)
        {
            var userDb = _userDbContext.Users.Find(id);
            if (userDb is not { } user) throw new NullReferenceException();
            user.name = name;
            _userDbContext.Entry(user).State = EntityState.Modified;
            _userDbContext.SaveChanges();
            return Ok(user);
        }

        [HttpDelete]
        public IActionResult DeleteUser(string id)
        {
            var userDb = _userDbContext.Users.Find(id);
            if (userDb is not { } user) throw new NullReferenceException();
            _userDbContext.Remove(userDb);
            _userDbContext.SaveChanges();
            return Ok();
        }

        [HttpGet("Invoices")]
        public IActionResult GetInvoicesWithA()
        {
            var userAndInvoice = _userDbContext.Users
                .Where(x => x.name.StartsWith("A"))
                .OrderBy(x => x.name)
                .Select(x => new { name = x.name });

            return Ok(userAndInvoice);
        }

        [HttpGet("InvoicesZ-getDates")]
        public IActionResult GetInvoiceWithZ()
        {
            var invoiceDates = _userDbContext.Users
                .Where(x => x.name.StartsWith("Z"))
                .Include(x => x.Invoices)
                .Select(x => new { invoiceDate = x.Invoices.Select(x => x.date) })
                .ToList();

            return Ok(invoiceDates);
        }

    }
}