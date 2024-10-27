using Microsoft.AspNetCore.Mvc;

namespace X_Clone_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ILogger<CommentController> _logger;

        public CommentController(ILogger<CommentController> logger)
        {
            _logger = logger;
        }

        //TODO:
        //1) Create POST create comments method
        //2) Create GET comments by post method
        //3) Create PUT update comments method
        //4) Create DELETE delete comments method
    }
}
