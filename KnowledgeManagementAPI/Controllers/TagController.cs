using CommandHandling.Abstractions;
using KnowledgeManagementAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QueryHandling.Abstractions;
using ReadModels;
using ReadModels.Query.Tag;
using ReadModels.ViewModel.Tag;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UseCases.CommandHandlers.TagCommands;
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
        public async Task<IActionResult> Post([FromBody] DefineTagDTO tagDTO)
        {
            if (tagDTO is null)
                throw new ArgumentNullException(nameof(tagDTO));
            await CommandBus.Send(DefineTagCommand.Create(Guid.NewGuid(), tagDTO.Title, tagDTO.CategoryId, false));       
            return Ok();
        }

        //public async Task<IActionResult> Post([FromBody] DefineTagDTO[] defineTagDTO)
        //{
        //    if (defineTagDTO is null || defineTagDTO.Length == 0)
        //        throw new ArgumentNullException(nameof(defineTagDTO));

        //    List<Task> listOfTasks = new();

        //    foreach (var tagDTO in defineTagDTO)
        //    {
        //        listOfTasks.Add(CommandBus.Send(DefineTagCommand.Create(Guid.NewGuid(), tagDTO.Title, tagDTO.CategoryId)));
        //    }

        //    await Task.WhenAll(listOfTasks);
        //    return Ok();
        //}

        [HttpPut]
        public async Task<IActionResult> Put(Guid id,[FromBody] ChangeTagPropertiesDTO changeTagPropertiesDTO)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException($"{nameof(id)}", $"{nameof(id)} cannot be null or empty.");
            if (changeTagPropertiesDTO is null)
                throw new ArgumentNullException(nameof(changeTagPropertiesDTO));
            await CommandBus.Send(ChangeTagPropertiesCommand.Create(id,changeTagPropertiesDTO.Title,changeTagPropertiesDTO.CategoryId,changeTagPropertiesDTO.IsActive));
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] TagFilterDTO TagFilter)
        {
            var Response = await QueryBus.Send<PagedViewModel<TagViewModel>, GetAllTagsQuery>(new GetAllTagsQuery( TagFilter.PageNumber, TagFilter.PageSize,TagFilter.CategoryId, TagFilter.Title, TagFilter.SortOrder));
            return Ok(JsonConvert.SerializeObject(Response));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TagViewModel>> Get(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException($"{nameof(id)}", $"{nameof(id)} cannot be null or empty.");
            var Response = await QueryBus.Send<TagViewModel, GetTagQuery>(new GetTagQuery(id));
            return Ok(JsonConvert.SerializeObject(Response));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException($"{nameof(id)}", $"{nameof(id)} cannot be null or empty.");
            await CommandBus.Send<DeleteTagCommand>(new DeleteTagCommand(id));
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] ChangeStatusDTO changeStatusDTO)
        {
            if (id == Guid.Empty) 
                throw new ArgumentNullException($"{nameof(id)}", $"{nameof(id)} cannot be null or empty.");
            if (changeStatusDTO is null)
                throw new ArgumentNullException(nameof(changeStatusDTO));
            await CommandBus.Send(new ChangeTagStatusCommand(id, changeStatusDTO.IsActive));
            return Ok();
        }


    }
}
