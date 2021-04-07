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
using Domain.Filter;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IMediator _mediatR;
        protected IMediator Mediator => _mediatR ??= HttpContext.RequestServices.GetService<IMediator>();

      
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("InsertClient")]
        public async Task<IActionResult> InsertClient(InsertClientCommand command)
        {
            try
            {
                _logger.LogInformation("succes calling api InsertClient");
                return Ok(await Mediator.Send(command));
            }
            catch (Exception e)
            {
                return BadRequest();
                _logger.LogError(e.Message);
            }
            
        }
        [HttpPost]
        [Route("InsertEmp")]
        public async Task<IActionResult> InsertEmp(InsertEmployeeCommand command)
        {            
            try
            {
                _logger.LogInformation("succes calling api InsertEmp");
                return Ok(await Mediator.Send(command));
            }
            catch (Exception e)
            {
                return BadRequest();
                _logger.LogError(e.Message);
            }
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers([FromQuery] PaginationFilter filter,string firstName = "" ,string lastName = "",string cityName = "")
        {
            try
            {
                _logger.LogInformation("succes calling api GetUsers");
                return Ok(await Mediator.Send(new GetUsersQuery { FirstName = firstName, LastName = lastName, CityName = cityName, Filter = filter }));
            }
            catch(Exception e)
            {
                return BadRequest();
                _logger.LogError(e.Message);
            }
        }


        [HttpGet]
        [Route("GetUserByID/{id}")]
        public async Task<IActionResult> GetUserByID(int id)
        {
            try
            {
                _logger.LogInformation("succes calling api GetUserByID");
                return Ok(await Mediator.Send(new GetUserByIDQuery { Id = id }));
            }
            catch (Exception e)
            {
                return BadRequest();
                _logger.LogError(e.Message);
            }           

        }

        [HttpPut]
        [Route("UpdateUser/{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                _logger.LogInformation("User not found!");
                return BadRequest();
            }

            try
            {
                _logger.LogInformation("succes calling api UpdateUser");
                 return Ok(await Mediator.Send(command));
            }
            catch (Exception e)
            {
                return BadRequest();
                _logger.LogError(e.Message);
            }
            
        }


    }
}
