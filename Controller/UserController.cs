using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MinimalJwt.Models;
using MinimalJwt.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MinimalJwt.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration configuration;
        public UserController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }
        [HttpPost]
        ActionResult<User> Login(UserLogin user, IUserService service)
        {
            
            return service.Get(user);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IResult GetById(int id, IUserService service)
        {
            var user = service.GetById(id);

            if (user is null) return Results.NotFound("User not found");

            return Results.Ok(user);
        }

        // GET api/<UserController>/5
        [HttpGet]
        public IResult UsersList(IUserService service)
        {
            var user = service.UsersList();

            if (user is null) return Results.NotFound("User not found");

            return Results.Ok(user);
        }

        // POST api/<UserController>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        [HttpPost]
        IResult Create(User user, IUserService service)
        {
            var result = service.Create(user);
            return Results.Ok(result);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        IResult Update(User newUser, IUserService service)
        {
            var updatedUser = service.Update(newUser);

            if (updatedUser is null) Results.NotFound("User not found");

            return Results.Ok(updatedUser);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        IResult Delete(int id, IUserService service)
        {
            var result = service.Delete(id);

            if (!result) Results.BadRequest("Something went wrong");

            return Results.Ok(result);
        }
    }
}
