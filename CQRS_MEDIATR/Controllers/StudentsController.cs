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
        private IBaseService<Student> _service;
        public StudentsController(IStudentService service)
        {
            _service = service;
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var result = await _service.GetStudent(p => p.Id == id);
            return Ok(result);
        }
    }
}
