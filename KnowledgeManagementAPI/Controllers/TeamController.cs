using CommandHandling.Abstractions;
using Commands.TeamCommands;
using KnowledgeManagementAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QueryHandling.Abstractions;
using ReadModels.Query.Team;
using ReadModels.ViewModel.Team;
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
        readonly IQueryBus _QueryBus;


        public TeamController(ICommandBus _CommandBus, IQueryBus _QueryBus, ITeamRepository teamRepository)
        {
            this._CommandBus = _CommandBus;
            this._QueryBus = _QueryBus;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TeamDefinitionDTO TeamDefinition)
        {
            if (TeamDefinition is null)
                throw new ArgumentNullException(nameof(TeamDefinition));

            await _CommandBus.Send(DefineTeamCommand.Create(Guid.NewGuid(), TeamDefinition.Title));
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] TeamFilterDTO TeamFilter)
        {
            var Response = await _QueryBus.Send<TeamViewModelList, GetAllTeamsQuery>(new GetAllTeamsQuery(Guid.NewGuid(), TeamFilter.PageNumber, TeamFilter.PageSize,TeamFilter.Title,TeamFilter.SortOrder));
            //var Response = teamRepository.GetAllTeams();
            //  return Ok(Response);
            // return Ok(JsonConvert.SerializeObject(Response.TeamViewModels));
            return Ok(JsonConvert.SerializeObject(new PagedResponse<IEnumerable<TeamViewModel>>(Response.TeamViewModels, Response.TotalCount)));
            //return Ok("THIS IS TEST...");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeamViewModel>> Get(Guid id)
        {
            var Response = await  _QueryBus.Send<TeamViewModel, GetTeamQuery>(new GetTeamQuery(id));
            //var Response = teamRepository.Find(id);
           // JsonConvert.SerializeObject(Response);
            return Ok(JsonConvert.SerializeObject(Response));
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
