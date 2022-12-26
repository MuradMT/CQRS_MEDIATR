using CQRS_MEDIATR.Data;
using CQRS_MEDIATR.Model;
using CQRS_MEDIATR.Services.Abstract.StudentService;
using CQRS_MEDIATR.Services.Concret.BaseService;
using System.Linq.Expressions;

namespace CQRS_MEDIATR.Services.Concret.StudentService
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        public StudentService(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
