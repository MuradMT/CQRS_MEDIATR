using CQRS_MEDIATR.Model;
using CQRS_MEDIATR.Services.Abstract.BaseService;
using System.Linq.Expressions;

namespace CQRS_MEDIATR.Services.Abstract.StudentService
{
    public interface IStudentService:IBaseService<Student>
    {
        
    }
}
