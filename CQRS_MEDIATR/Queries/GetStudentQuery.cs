using CQRS_MEDIATR.Model;


namespace CQRS_MEDIATR.Queries
{
    public class GetStudentQuery:IRequest<ServiceResponse>
    {
        public int Id { get; }
        public GetStudentQuery(int id)
        {
            Id = id;
        }
    }
}
