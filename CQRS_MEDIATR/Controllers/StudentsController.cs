using AutoMapper;
using Azure;
using CQRS_MEDIATR.Commands;
using CQRS_MEDIATR.Mapping;
using CQRS_MEDIATR.Model;
using CQRS_MEDIATR.Model.Dto;
using CQRS_MEDIATR.Queries;
using CQRS_MEDIATR.Services.Abstract.BaseService;
using CQRS_MEDIATR.Services.Abstract.StudentService;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CQRS_MEDIATR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IMediator _mediator;
        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ServiceResponse>> GetStudent(int id)
        {
            var query = new GetStudentQuery(id);
            var response = await _mediator.Send(query);
            if (response == null && response.Success == false) return BadRequest(response);
            return Ok(response);
        }
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ServiceResponse>> GetStudents()
        {

            var query = new GetStudentsQuery();
            var response = await _mediator.Send(query);
            if (response == null && response.Success == false) return BadRequest(response);
            return Ok(response);
        }
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ServiceResponse>> AddStudent([FromBody] StudentCreateDto studentCreateDto)
        {
            var command = new AddStudentCommand(studentCreateDto);
            var response = await _mediator.Send(command);
            if (response == null && response.Success == false) return BadRequest(response);
            return Ok(response);
        }
        [HttpDelete("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ServiceResponse>> DeleteStudent(int id)
        {
            var command = new DeleteStudentCommand(id);
            var response = await _mediator.Send(command);
            if (response == null && response.Success == false) return BadRequest(response);
            return Ok(response);
        }
        [HttpPut("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ServiceResponse>> UpdateStudent(int id, [FromBody] StudentUpdateDto studentUpdateDto)
        {
            var command = new UpdateStudentCommand(id, studentUpdateDto);
            var response = await _mediator.Send(command);
            if (response == null && response.Success == false) return BadRequest(response);
            return Ok(response);
        }
    }
}
