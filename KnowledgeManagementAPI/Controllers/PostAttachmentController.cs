using CommandHandling.Abstractions;
using KnowledgeManagementAPI.DTOs.PostAttachment;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QueryHandling.Abstractions;
using ReadModels.Query.PostAttachment;
using ReadModels.ViewModel;
using ReadModels.ViewModel.PostAttachment;
using System;
using System.Threading.Tasks;
using UseCases.Commands.PostAttachment;

namespace KnowledgeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostAttachmentController : ControllerBase
    {
        private readonly ICommandBus commandBus;
        private readonly IQueryBus queryBus;
        public PostAttachmentController(ICommandBus commandBus, IQueryBus queryBus)
        {
            this.commandBus = commandBus;
            this.queryBus = queryBus;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostAttachFileDTO postAttachFileDTO)
        {
            if (postAttachFileDTO == null)
                throw new ArgumentNullException(nameof(postAttachFileDTO));
            await commandBus.Send(new PostAttachFileCommand(Guid.NewGuid(), postAttachFileDTO.Title, postAttachFileDTO.PostId,
                postAttachFileDTO.UserId, postAttachFileDTO.File));
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetPostAttachmentListDTO getPostAttachmentListDTO)
        {
            if (getPostAttachmentListDTO == null)
                throw new ArgumentNullException(nameof(getPostAttachmentListDTO));
            var Response = await queryBus.Send<PagedViewModel<UserPostAttachmentViewModel>, GetPostAllAttachmentsQuery>
                (new GetPostAllAttachmentsQuery(getPostAttachmentListDTO.PageNumber, getPostAttachmentListDTO.PageNumber, getPostAttachmentListDTO.PostId));
            return Ok(JsonConvert.SerializeObject(Response));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid PostId)
        {
            var Response = await queryBus.Send<PostAttachmentFileViewModel, GetPostAttachmentFileQuery>(new GetPostAttachmentFileQuery(PostId));
            return Ok(JsonConvert.SerializeObject(Response));
        }
    }
}
