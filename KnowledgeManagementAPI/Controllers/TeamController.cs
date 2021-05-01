using CommandHandling.Abstractions;
using Commands.TeamCommands;
using KnowledgeManagementAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        readonly ICommandBus _CommandBus;

        public TeamController(ICommandBus _CommandBus)
        {
            this._CommandBus = _CommandBus;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TeamDefinitionDTO TeamDefinition)
        {
            if (TeamDefinition is null)
                throw new ArgumentNullException(nameof(TeamDefinition));

            await _CommandBus.Send<DefineTeamCommand>(new DefineTeamCommand(new Guid(), TeamDefinition.Title));
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //if (TeamDefinition is null)
                throw new ArgumentNullException("THIS IS TEST...");

            //await _CommandBus.Send<DefineTeamCommand>(new DefineTeamCommand(new Guid(), TeamDefinition.Title));
            //return Ok();
        }
    }
}
