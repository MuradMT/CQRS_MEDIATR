using CQRS_MEDIATR.Model;


namespace CQRS_MEDIATR.Commands
{
    public class DeleteStudentCommand:IRequest<ServiceResponse>
    {
        public int Id { get; }
        public DeleteStudentCommand(int id)
        {
            Id = id;
        }
    }
}
