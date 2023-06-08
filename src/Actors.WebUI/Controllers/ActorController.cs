using Actors.Application.Features.Actors.Commands.AddActor;
using Actors.Application.Features.Actors.Commands.AddActorMovies;
using Actors.Application.Features.Actors.Models;
using Actors.Application.Features.Actors.Queries.GetActor;
using Actors.Application.Features.Actors.Queries.GetActorMovies;
using Actors.Application.Features.Actors.Queries.GetActors;
using Actors.WebUI.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Actors.WebUI.Controllers;

[ApiController]
[Route("Actors")]
public class ActorController : ControllerBase
{
    private readonly ISender _mediator;
    public ActorController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ActorVm>), (int)HttpStatusCode.OK)]
    public async Task<List<ActorVm>> GetActors([FromQuery] GetActorsQuery command)
      => await _mediator.Send(command);

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ActorVm), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<ActorVm> GetActors(Guid id)
    => await _mediator.Send(new GetActorQuery(id));

    [HttpGet("{id:guid}/movies")]
    [ProducesResponseType(typeof(List<MovieVm>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<List<MovieVm>> GetActorMovies(Guid id)
    => await _mediator.Send(new GetActorMoviesQuery(id));

    [HttpPost]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
    public async Task<Guid> AddActor([FromBody] AddActorCommand command)
      => await _mediator.Send(command);

    [HttpPost("{id:guid}/movie")]
    [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
    public async Task<Unit> AddActorMovie(Guid id, [FromBody] MovieDTO movie)
      => await _mediator.Send(new AddActorMoviesCommand(id, movie.MovieName, movie.MovieReleaseDate));


}
