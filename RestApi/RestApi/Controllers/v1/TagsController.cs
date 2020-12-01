using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestApi.Contracts.v1;
using RestApi.Contracts.v1.Requests;
using RestApi.Domain;
using RestApi.Extensions;
using RestApi.Services;
using System;
using System.Threading.Tasks;

namespace RestApi.Controllers.v1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Poster")]
    public class TagsController : Controller
    {
        private readonly IPostService _postService;
        public TagsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet(ApiRoutes.Tags.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _postService.GetTagsAsync());
        }

        [HttpGet(ApiRoutes.Tags.Get)]
        public async Task<IActionResult> Get([FromRoute] string tagName)
        {
            var tag = await _postService.GetTagByNameAsync(tagName);
            if (tag == null)
            {
                return NotFound();
            }

            return Ok(tag);
        }

        [HttpPost(ApiRoutes.Tags.Create)]
        public async Task<IActionResult> Create([FromRoute] CreateTagRequest request)
        {
            var newTag = new Tag
            {
                Name = request.Name,
                CreatorId = HttpContext.GetUserId(),
                CreatedOn = DateTime.UtcNow
            };

            var created = await _postService.CreateTagAsync(newTag);
            if (!created)
            {
                return BadRequest(new { error = "Unable to create tag" });
            }

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locaationUri = baseUrl + "/" + ApiRoutes.Tags.Get.Replace("{tagName}", newTag.Name);
            return Created(locaationUri, newTag);
        }

        [HttpDelete(ApiRoutes.Tags.Delete)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] string tagName)
        {
            var deleted = await _postService.DeleteTagAsync(tagName);
            if (deleted)
            {
                return NoContent();
            }
            return BadRequest(new { error = "Unable to delete tag" });
        }
    }
}
