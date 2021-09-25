﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using NetCore.Infrastructure.Database.Handlers;
using System;
using System.Threading.Tasks;

namespace NetCore.Api.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/values
        [HttpGet]
        //[Authorize(Roles="user")]
        [EnableQuery]
        public async Task<ActionResult> Get(QueryPersonRequest request)
{
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreatePersonRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
{
            var response = await _mediator.Send(new DeletePersonRequest(id));
            return Ok(response);
        }
    }
}
