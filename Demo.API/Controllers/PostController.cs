using Demo.BusinessTier.Services;
using Demo.BusinessTier.Services.Implements;
using Demo.DataTier.Data;
using Demo.DataTier.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            this._postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            try
            {
                List<Post> posts = await _postService.GetPosts();
                if (posts.Count > 0)
                {
                    return Ok(new
                    {
                        StatusCode= 200,
                        data= posts
                    });
                }
                else
                {
                    return NotFound(new
                    {
                        Message = "Empty list",
                        StatusCode = 404,
                    });
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
