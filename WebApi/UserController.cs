using DAL.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi
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

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_userDbContext.Users);
        }
    }
}
