using Application.FeaturesUser.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Application.FeaturesUser.Commands;
using Domain.DataTransferObject;
using WebAPI.Wrapper;
using Domain.Filter;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IMediator _mediatR;
        protected IMediator Mediator => _mediatR ??= HttpContext.RequestServices.GetService<IMediator>();

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

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers([FromQuery] PaginationFilter filter,string firstName = "" ,string lastName = "",string cityName = "")
        {            
            return Ok(await Mediator.Send(new GetUsersQuery { FirstName = firstName, LastName = lastName, CityName = cityName, Filter = filter}));
        }


        [HttpGet]
        [Route("GetUserByID/{id}")]
        public async Task<IActionResult> GetUserByID(int id)
        {
            return Ok(await Mediator.Send(new GetUserByIDQuery { Id = id }));

        }

        [HttpPut]
        [Route("UpdateUser/{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }


    }
}
