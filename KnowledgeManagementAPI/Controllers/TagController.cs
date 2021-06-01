using CommandHandling.Abstractions;
using KnowledgeManagementAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public TagController(ICommandBus commandBus)
        {
            CommandBus = commandBus;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DefineTagDTO defineTagDTO )
        {
            if (defineTagDTO is null)
                throw new ArgumentNullException(nameof(defineTagDTO));

            await CommandBus.Send(DefineTagCommand.Create(Guid.NewGuid(), defineTagDTO.Title, defineTagDTO.CategoryId));
            return Ok();
        }
    }
}
