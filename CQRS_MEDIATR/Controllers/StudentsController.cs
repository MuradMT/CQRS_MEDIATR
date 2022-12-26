using CQRS_MEDIATR.Model;
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
        private IStudentService _service;
        public StudentsController(IStudentService service)
        {
            _service = service;
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<ServiceResponse<Student>>> GetStudent(int id)
        {
            var result = await _service.Get(p => p.Id == id);
            var response=new ServiceResponse<Student>()
            {
                Data = result
            };
            if (!response.Success)
            {
                response.Success = false;
                response.Message = "wrong";
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
