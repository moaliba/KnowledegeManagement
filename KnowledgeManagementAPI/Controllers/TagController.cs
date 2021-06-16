using CommandHandling.Abstractions;
using KnowledgeManagementAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QueryHandling.Abstractions;
using ReadModels.Query.Tag;
using ReadModels.ViewModel;
using ReadModels.ViewModel.Tag;
using System;
using System.Threading.Tasks;
using UseCases.CommandHandlers.TagCommands;
using UseCases.Commands.TagCommands;
using KnowledgeManagementAPI.Filters;

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
        [PersianConvertorFilter("tagDTO")]
        public async Task<IActionResult> Post([FromBody] DefineTagDTO tagDTO)
        {
            if (tagDTO is null)
                throw new ArgumentNullException(nameof(tagDTO));
            await CommandBus.Send(DefineTagCommand.Create(Guid.NewGuid(), tagDTO.Title, tagDTO.CategoryId,tagDTO.IsActive, false));       
            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id,[FromBody] ChangeTagPropertiesDTO changeTagPropertiesDTO)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException($"{nameof(id)}", $"{nameof(id)} cannot be null or empty.");
            if (changeTagPropertiesDTO is null)
                throw new ArgumentNullException(nameof(changeTagPropertiesDTO));
            await CommandBus.Send(ChangeTagPropertiesCommand.Create(id,changeTagPropertiesDTO.Title.ToPersianString(),changeTagPropertiesDTO.CategoryId,changeTagPropertiesDTO.IsActive));
            return Ok();
        }

        [HttpGet]
        [ActionName("GetByAdmin")]
        [Route("GetByAdmin")]
        [PersianConvertorFilter("TagFilter")]
        public async Task<IActionResult> GetByAdmin([FromQuery] TagFilterDTO TagFilter)
        {
            var Response = await QueryBus.Send<PagedViewModel<TagViewModel>, GetAllTagsQuery>(new GetAllTagsQuery( TagFilter.PageNumber, TagFilter.PageSize,TagFilter.CategoryId, TagFilter.Title, TagFilter.SortOrder.NormalizedInput()));
            return Ok(JsonConvert.SerializeObject(Response));
        }

        [HttpGet]
        [PersianConvertorFilter("TagFilter")]
        public async Task<IActionResult> Get([FromQuery] TagFilterDTO TagFilter)
        {
            var Response = await QueryBus.Send<PagedViewModel<UserTagViewModel>, GetTagsByUserQuery>(new GetTagsByUserQuery(TagFilter.PageNumber, TagFilter.PageSize, TagFilter.CategoryId, TagFilter.Title));
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
