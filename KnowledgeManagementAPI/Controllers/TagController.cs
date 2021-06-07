using CommandHandling.Abstractions;
using KnowledgeManagementAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QueryHandling.Abstractions;
using ReadModels.Query.Tag;
using ReadModels.ViewModel.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseCases.Commands.TagCommands;

namespace KnowledgeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        readonly ICommandBus CommandBus;
        readonly IQueryBus QueryBus;
        public TagController(ICommandBus commandBus, IQueryBus queryBus)
        {
            CommandBus = commandBus;
            QueryBus = queryBus;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DefineTagDTO defineTagDTO )
        {
            if (defineTagDTO is null)
                throw new ArgumentNullException(nameof(defineTagDTO));

            await CommandBus.Send(DefineTagCommand.Create(Guid.NewGuid(), defineTagDTO.Title, defineTagDTO.CategoryId));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Guid id,[FromBody] ChangeStatusDTO changeStatusDTO)
        {
            if (changeStatusDTO is null)
                throw new ArgumentNullException(nameof(changeStatusDTO));
            await CommandBus.Send(new ChangeTagStatusCommand(id, changeStatusDTO.Status));
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] TagFilterDTO TagFilter)
        {
            var Response = await QueryBus.Send<TagViewModelList, GetAllTagsQuery>(new GetAllTagsQuery( TagFilter.PageNumber, TagFilter.PageSize,TagFilter.CategoryId, TagFilter.Title, TagFilter.SortOrder));
            return Ok(JsonConvert.SerializeObject(new PagedResponse<IEnumerable<TagViewModel>>(Response.TagViewModels, Response.TotalCount)));
            //return Ok("THIS IS TEST...");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TagViewModel>> Get(Guid id)
        {
            var Response = await QueryBus.Send<TagViewModel, GetTagQuery>(new GetTagQuery(id));
            return Ok(JsonConvert.SerializeObject(Response));
        }
    }
}
