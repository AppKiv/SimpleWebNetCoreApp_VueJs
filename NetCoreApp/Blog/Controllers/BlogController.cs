using Blog.Model;
using Blog.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace Blog
{
    [Route("api/[controller]")]
    [EnableCors("local8080")]
    public class BlogController : Controller
    {
        IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        // http://localhost:59998/api/blog/posts?id=0&tags=sql
        // http://localhost:59998/api/blog/posts
        [Route("posts")]
        [HttpGet]
        public JsonResult GetPosts(int id = 0, string tags = "")
        {
            if (id > 0)
                return Json(_blogService.GetPostsById(id));

            if (tags.Length > 0)
                return Json(_blogService.GetPostsByTag(tags));

            return Json(_blogService.GetPosts());
        }

        // http://localhost:59998/api/blog/posts/112
        [HttpGet("posts/{id:int}")]
        public JsonResult GetPost(int id)
        {
            return GetPosts(id);
        }

        // http://localhost:59998/api/blog/tags
        [Route("tags")]
        [HttpGet]
        public async Task<JsonResult> GetTags()
        {
            var tags = await _blogService.GetTagsAsyncPage();
            return Json(tags);
        }

        [Authorize]
        [HttpPut("posts/{id:int}")]
        public void EditPosts(PostModel data)
        {

        }

        [Authorize]
        [HttpPost("posts")]
        public void NewPosts(PostModel data)
        {

        }
    }
}
