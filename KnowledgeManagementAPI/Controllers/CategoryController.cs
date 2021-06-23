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
using KnowledgeManagementAPI.Filters;
using UseCases.Commands.CategoryCommands;

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
        [PersianConvertorFilter("CategoryDefinition")]
        public async Task<ActionResult> Post([FromBody] CategoryDefinitionDTO CategoryDefinition)
        {
            if (CategoryDefinition == null)
                throw new ArgumentNullException(nameof(CategoryDefinition));
            await commandBus.Send(DefineCategoryCommand.Create(Guid.NewGuid(), CategoryDefinition.Title, CategoryDefinition.IsActive));
            return Ok();
        }

        [HttpPut("{id}")]
        [PersianConvertorFilter("CategoryChangeProperties")]
        public async Task<ActionResult> Put(Guid id, [FromBody] CategoryChangePropertiesDTO CategoryChangeProperties)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException($"{nameof(id)}", $"{nameof(id)} cannot be null or empty.");
            if (CategoryChangeProperties == null)
                throw new ArgumentNullException(nameof(CategoryChangeProperties));
            await commandBus.Send(ChangeCategoryPropertiesCommand.Create(id, CategoryChangeProperties.Title,
                                                                        CategoryChangeProperties.IsActive));
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] CategoryChangeStatusDTO categoryChangeStatus)
        {
            if (categoryChangeStatus == null)
                throw new ArgumentNullException(nameof(categoryChangeStatus));
            if (id == Guid.Empty)
                throw new ArgumentNullException($"{nameof(id)}", $"{nameof(id)} cannot be null or empty.");
            await commandBus.Send(new CategoryChangeStatusCommand(id, categoryChangeStatus.IsActive));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException($"{nameof(id)}", $"{nameof(id)} can not be null or empty!!!");
            await commandBus.Send(DeleteCategoryCommand.Create(id));
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryViewModel>> Get(Guid Id)
        {
            if (Id == Guid.Empty)
                throw new ArgumentNullException($"{nameof(Id)}", $"{nameof(Id)} cannot be null or empty.");
            var Response = await queryBus.Send<CategoryViewModel, GetCategoryQuery>(new GetCategoryQuery(Id));
            return Ok(JsonConvert.SerializeObject(Response));
        }

        [HttpGet]
        [ActionName("GetByAdmin")]
        [Route("GetByAdmin")]
        [PersianConvertorFilter("categoryList")]
        public async Task<IActionResult> GetByAdmin([FromQuery] GetCategoryListDTO categoryList)
        {
            var Response = await queryBus.Send<PagedViewModel<CategoryViewModel>, GetCategoryListQuery>(new GetCategoryListQuery(
                    Guid.NewGuid(), categoryList.PageNumber, categoryList.PageSize, categoryList.CategoryTitle, categoryList.IsActive,
                    categoryList.SortOrder.NormalizedInput()));
            return Ok(JsonConvert.SerializeObject(Response));
        }

        [HttpGet]
        [PersianConvertorFilter("userGetCategoryList")]
        public async Task<IActionResult> Get([FromQuery] UserGetCategoryListDTO userGetCategoryList)
        {
            var Response = await queryBus.Send<PagedViewModel<CategoryViewModel>, UserGetCategoryListQuery>(new UserGetCategoryListQuery(
                    Guid.NewGuid(), userGetCategoryList.PageNumber, userGetCategoryList.PageSize, userGetCategoryList.CategoryTitle,
                    userGetCategoryList.SortOrder.NormalizedInput()));
            return Ok(JsonConvert.SerializeObject(Response));
        }
    }
}
