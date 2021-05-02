using CommandHandling.Abstractions;
using Commands.TeamCommands;
using KnowledgeManagementAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseCases.RepositoryContracts;

namespace KnowledgeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        readonly ICommandBus _CommandBus;
        readonly ITeamRepository teamRepository;

        public TeamController(ICommandBus _CommandBus, ITeamRepository teamRepository)
        {
            this._CommandBus = _CommandBus;
            this.teamRepository = teamRepository;
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
            var Response =  teamRepository.GetAllTeams();
            return Ok(Response);
            //return Ok("THIS IS TEST...");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _CommandBus.Send<DeleteTeamCommand>(new DeleteTeamCommand(id));        
            return Ok();

        }
    }
}
