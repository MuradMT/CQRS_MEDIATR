using CQRS_MEDIATR.Model;
using CQRS_MEDIATR.Model.Dto;


namespace CQRS_MEDIATR.Commands
{
    public class AddStudentCommand:IRequest<ServiceResponse>
    {
        public StudentCreateDto _dto { get; }
        public AddStudentCommand(StudentCreateDto dto)
        {
            _dto = dto;
        }
    }
}
