using CommandHandling.Abstractions;
using KnowledgeManagementAPI.DTOs.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseCases.Commands.Post;

namespace KnowledgeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ICommandBus commandBus;

        public PostController(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostDTO postDTO)
        {
            if (postDTO == null)
                throw new ArgumentNullException(nameof(postDTO));
            await commandBus.Send(PostCommand.Create(Guid.NewGuid(), postDTO.PostTitle, postDTO.PostContent, postDTO.CategoryId, postDTO.UserID, postDTO.Tags));
            return Ok();
        }
    }
}
