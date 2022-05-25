﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetCore.Api.Controllers
{

    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    // [Authorize(Roles = "user")]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizedBaseController : ControllerBase
    {
    }
}
