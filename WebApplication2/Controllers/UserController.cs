using DAL.Infrastructure;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

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
            return Ok(_userDbContext.Users);
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


        
    }
}