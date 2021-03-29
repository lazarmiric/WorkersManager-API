using Application.FeaturesUser.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Application.FeaturesUser.Commands;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IMediator _mediatR;
        protected IMediator Mediator => _mediatR ??= HttpContext.RequestServices.GetService<IMediator>();



    }

    [HttpPost]
            [Route("InsertClient")]
            public async Task<IActionResult> InsertClient(InsertClientCommand command)
            {
                return Ok(await Mediator.Send(command));
            }
            [HttpPost]
            [Route("InsertEmp")]
            public async Task<IActionResult> InsertEmp(InsertEmployeeCommand command)
            {
                return Ok(await Mediator.Send(command));
            }
            [HttpGet]
            [Route("GetUsers")]
            public async Task<IActionResult> GetUsers()
            {
                return Ok(await Mediator.Send(new GetUsersQuery()));
            }
}
