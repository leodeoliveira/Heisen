using Heisen.Core.Abstraction;
using Heisen.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_userService.Get());
        }

        [HttpPost]
        public JsonResult Add(User user)
        {
            return new JsonResult(_userService.Add(user));
        }

        [HttpPut]
        public JsonResult Put(User user)
        {
            return new JsonResult(_userService.Update(user));
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            return new JsonResult(_userService.Delete(id));
        }

        [HttpPost]
        public JsonResult ValidateUserCredentials(string username, string password)
        {
            return new JsonResult(_userService.ValidateUserCredentials(username, password));
        }
    }
}
