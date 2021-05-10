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
        public IActionResult Get()
        {
            var Response = teamRepository.GetAllTeams();
            return Ok(Response);
            //return Ok("THIS IS TEST...");
        }


        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var Response = teamRepository.Find(id);
            return Ok(Response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _CommandBus.Send<DeleteTeamCommand>(new DeleteTeamCommand(id));        
            return Ok();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] TeamDefinitionDTO input)
        {
            if (input is null)
                throw new ArgumentNullException(nameof(input));

            await _CommandBus.Send<ChangeTeamTitleCommand>(new ChangeTeamTitleCommand(id, input.Title));
            return Ok();
        }
    }
}
