using CommandHandling.Abstractions;
using KnowledgeManagementAPI.DTOs.Category;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Commands.CategoryCommands;

namespace KnowledgeManagementAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class CategoryController : Controller
    {
        readonly ICommandBus commandBus;
        public CategoryController(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
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
    }
}
