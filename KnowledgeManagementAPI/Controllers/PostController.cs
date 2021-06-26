using CommandHandling.Abstractions;
using KnowledgeManagementAPI.DTOs.Post;
using KnowledgeManagementAPI.DTOs.PostAttachment;
using KnowledgeManagementAPI.Filters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QueryHandling.Abstractions;
using ReadModels.Query.Post;
using ReadModels.ViewModel;
using ReadModels.ViewModel.Post;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UseCases.Commands.Post;
using UseCases.Commands.PostAttachment;

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
        [PersianConvertorFilter("postDTO")]
        public async Task<IActionResult> Post([FromForm] PostDTO postDTO)
        {
            if (postDTO == null)
                throw new ArgumentNullException(nameof(postDTO));

            List<PostAttachmentFileDataStructure> FileList = new();
            foreach (PostAttachFileDTO Attachment in postDTO.FileList)
                FileList.Add(PostAttachmentFileDataStructure.Create(Guid.NewGuid(), Attachment.Title, Attachment.File));

            await commandBus.Send(PostCommand.Create(Guid.NewGuid(), postDTO.PostTitle, postDTO.PostContent,
                                                        postDTO.CategoryId, new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), postDTO.Tags, FileList));
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetPostDTO getPostDTO)
        {
            if (getPostDTO == null)
                throw new ArgumentNullException(nameof(getPostDTO));
            var response = await queryBus.Send<PagedViewModel<PostViewModel>, GetPostListQuery>
                                                                (new GetPostListQuery(getPostDTO.PageNumber, getPostDTO.PageSize, getPostDTO.CategoryID,
                                                                                    getPostDTO.PostTitle, getPostDTO.Tags, getPostDTO.SortOrder));

            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException($"{nameof(id)}", $"{nameof(id)} cannot be null or empty.");

            var response = await queryBus.Send<PostWithAttachmentViewModel, GetPostQuery>(new GetPostQuery(id));
            return Ok(JsonConvert.SerializeObject(response));
        }
    }
}
