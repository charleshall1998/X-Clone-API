using Microsoft.AspNetCore.Mvc;

namespace X_Clone_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        //TODO:
        //1) Create POST create users method
        //2) Create GET users by email method
        //3) Create PUT update users method
        //4) Create DELETE delete users method
    }
}
