using CommandHandling.Abstractions;
using KnowledgeManagementAPI.DTOs.Category;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Commands.CategoryCommands;
using QueryHandling.Abstractions;
using ReadModels.ViewModel;
using ReadModels.Query.Category;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace KnowledgeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly ICommandBus commandBus;
        readonly IQueryBus queryBus;
        public CategoryController(ICommandBus commandBus, IQueryBus queryBus)
        {
            this.commandBus = commandBus;
            this.queryBus = queryBus;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDefinitionDTO CategoryDefinition)
        {
            if (CategoryDefinition == null)
                throw new ArgumentNullException(nameof(CategoryDefinition));
            await commandBus.Send(DefineCategoryCommand.Create(Guid.NewGuid(), CategoryDefinition.Title));
            return Ok();
        }

        [HttpPut("id")]
        public async Task<ActionResult> Put([FromBody] CategoryChangeTitleDTO CategoryChangeTitle)
        {
            if (CategoryChangeTitle == null)
                throw new ArgumentNullException(nameof(CategoryChangeTitle));
            await commandBus.Send(ChangeCategoryTitleCommand.Create(CategoryChangeTitle.CategoryId, CategoryChangeTitle.Title));
            return Ok();
        }

        [HttpGet("id")]
        public async Task<ActionResult<CategoryViewModel>> Get(Guid Id)
        {
            var Response = await queryBus.Send<CategoryViewModel, GetCategoryQuery>(new GetCategoryQuery(Id));
            return Ok(JsonConvert.SerializeObject(Response));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetCategoryListDTO categoryList)
        {
            var Response = await queryBus.Send<CategoryViewModelList, GetCategoryListQuery>(new GetCategoryListQuery(
                    Guid.NewGuid(), categoryList.PageNumber, categoryList.PageSize, categoryList.CategoryTitle, categoryList.SortOrder));
            return Ok(JsonConvert.SerializeObject(new PagedResponse<IEnumerable<CategoryViewModel>>(Response.CategoryViewModels, Response.TotalCount)));
        }
    }
}
