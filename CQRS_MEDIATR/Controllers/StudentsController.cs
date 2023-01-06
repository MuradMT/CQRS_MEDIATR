using AutoMapper;
using Azure;
using CQRS_MEDIATR.Mapping;
using CQRS_MEDIATR.Model;
using CQRS_MEDIATR.Model.Dto;
using CQRS_MEDIATR.Services.Abstract.BaseService;
using CQRS_MEDIATR.Services.Abstract.StudentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MEDIATR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //Tomorrow i will start to use cqrs architectural and mediatr  design patterns
        private IStudentService _service;
        private IMapper _mapper;
        public StudentsController(IStudentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ServiceResponse>> GetStudent(int id)
        {
            var response = new ServiceResponse();
            try
            {
                var result = await _service.Get(p => p.Id == id);
                if (result == null)
                {
                    return NotFound(null);
                }
                response.Data = result;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ServiceResponse>> GetStudents()
        {
            var response = new ServiceResponse();
            try
            {
                var result = await _service.GetAll();
                if (result == null)
                {
                    return NotFound(null);
                }
                response.Data = result;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ServiceResponse>> AddStudent([FromBody] StudentCreateDto studentCreateDto)
        {
            var response = new ServiceResponse();
            try
            {
                if (studentCreateDto == null)
                {
                    return NotFound(null);
                }
                var result = _mapper.Map<Student>(studentCreateDto);
                await _service.Add(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
        [HttpDelete("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ServiceResponse>> DeleteStudent(int id)
        {
            var response = new ServiceResponse();
            try
            {
                var result=await _service.Get(p=>p.Id== id);  

                if (result == null)
                {
                    response.Message = "there is no existing data";
                    return NotFound(response);
                }
                
                await _service.Delete(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
        [HttpPut("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ServiceResponse>> UpdateStudent(int id,[FromBody]StudentUpdateDto studentUpdateDto)
        {
            var response = new ServiceResponse();
            try
            {
                if (id != studentUpdateDto.Id||studentUpdateDto==null)
                {
                    response.Message = "updating is wrong";
                    return NotFound(response);
                }
                var result = _mapper.Map<Student>(studentUpdateDto);

                if (result == null)
                {
                    response.Message = "mapping is not happened";
                    return NotFound(response);
                }

                await _service.Update(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
    }
}
