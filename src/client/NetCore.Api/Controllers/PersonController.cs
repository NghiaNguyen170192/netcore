﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using NetCore.Application.Commands;
using NetCore.Application.Commands.Dtos;
using NetCore.Application.Queries;
using NetCore.Application.Queries.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.Api.Controllers;

public class PersonController : AuthorizedBaseController
{
    private readonly IMediator _mediator;

    public PersonController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET api/values
    [HttpGet]
    public async Task<ActionResult> Get(Guid id)
    {
        var response = await _mediator.Send(new PersonQuery(id));
        return Ok(response);
    }

    // POST api/values
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreatePersonCommand request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(Guid id, [FromBody] UpdatePersonDto model)
    {
        var request = new UpdatePersonCommand(id, model.NameConst, model.PrimaryName, model.BirthYear, model.DeathYear);
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var response = await _mediator.Send(new DeletePersonCommand(id));
        return Ok(response);
    }

    [HttpGet]
    [EnableQuery]
    [Route("~/api/v1/persons")]
    public async Task<ActionResult<IEnumerable<PersonQueryDto>>> GetPersons()
    {
        var response = await _mediator.Send(new PersonsQuery());
        return Ok(response);
    }
}