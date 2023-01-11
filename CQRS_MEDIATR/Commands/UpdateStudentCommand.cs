using CQRS_MEDIATR.Model;
using CQRS_MEDIATR.Model.Dto;

namespace CQRS_MEDIATR.Commands
{
    public class UpdateStudentCommand:IRequest<ServiceResponse>
    {
        public int Id { get;  }
        public StudentUpdateDto _dto { get; }
        public UpdateStudentCommand(int id, StudentUpdateDto dto)
        {
            Id = id;
            _dto = dto;
        }
    }
}
