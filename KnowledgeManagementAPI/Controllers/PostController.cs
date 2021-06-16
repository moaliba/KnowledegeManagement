using CommandHandling.Abstractions;
using KnowledgeManagementAPI.DTOs.Post;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QueryHandling.Abstractions;
using ReadModels.Query.Post;
using ReadModels.ViewModel;
using ReadModels.ViewModel.Post;
using System;
using System.Threading.Tasks;
using UseCases.Commands.Post;

namespace KnowledgeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ICommandBus commandBus;
        private readonly IQueryBus queryBus;

        public PostController(ICommandBus commandBus, IQueryBus queryBus)
        {
            this.commandBus = commandBus;
            this.queryBus = queryBus;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostDTO postDTO)
        {
            if (postDTO == null)
                throw new ArgumentNullException(nameof(postDTO));
            await commandBus.Send(PostCommand.Create(Guid.NewGuid(), postDTO.PostTitle, postDTO.PostContent,
                                                        postDTO.CategoryId, postDTO.UserID, postDTO.Tags));
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromBody] GetPostDTO getPostDTO)
        {
            if (getPostDTO == null)
                throw new ArgumentNullException(nameof(getPostDTO));
            var response = await queryBus.Send<PagedViewModel<PostViewModel>, GetPostQuery>
                                                                (new GetPostQuery( getPostDTO.PageNumber, getPostDTO.PageSize, getPostDTO.CategoryID,
                                                                                    getPostDTO.PostTitle, getPostDTO.Tags, getPostDTO.SortOrder));

            return Ok(JsonConvert.SerializeObject(response));
        }
    }
}
