using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Web_API.Business.Validations;
using Web_API.Data;
using Web_API.Models;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebApi : ControllerBase
    {
        private readonly UserServices _userServices;
        private readonly ValidateUser _userValidation;
        private readonly ILogger<WebApi> _logger;
        public WebApi(
            UserServices userServices,
            ValidateUser userValidation,
            ILogger<WebApi> logger)
        {
            _logger = logger;
            _userValidation = userValidation;
            _userServices = userServices;
        }

        [HttpGet("GetUser")]
        public List<User> Get()
        {
            return _userServices.GetAll();
        }
        [HttpPut("CreateUser")]
        public bool Create(User user)
        {
            if (_userValidation.ValidateUserData(user) == false)
            {
                throw new ArgumentException("User ou Password not valid");
            };
            _userServices.CreateUser(user);
            return true;
        }

        [HttpPut("ChangeUserByName")]
        public bool UpdateById(User user)
        {
            _userServices.UpdateUserName(user._id, user.username);
            return true;
        }

        [HttpDelete("DeleteById")]
        public bool DeleteById(string id)
        {
            _userServices.DeleteUserById(id);
            return true;
        }
    }
}