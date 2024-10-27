using Microsoft.AspNetCore.Mvc;

namespace X_Clone_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;

        public PostController(ILogger<PostController> logger)
        {
            _logger = logger;
        }

        //TODO:
        //1) Create POST create posts method
        //2) Create GET posts method
        //3) Create GET posts by user method
        //4) Create PUT update posts method
        //5) Create DELETE delete posts method
    }
}
