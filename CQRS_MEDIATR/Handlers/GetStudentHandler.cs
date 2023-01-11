using CQRS_MEDIATR.Model;
using CQRS_MEDIATR.Queries;
using CQRS_MEDIATR.Services.Abstract.StudentService;


namespace CQRS_MEDIATR.Handlers
{
    public class GetStudentHandler : IRequestHandler<GetStudentQuery, ServiceResponse>
    {
        private IStudentService _service;
        private ILogger<Student> _logger;
        public GetStudentHandler(IStudentService service, ILogger<Student> logger)
        {
            _service = service;
            _logger = logger;
        }
        public async Task<ServiceResponse> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            var response = new ServiceResponse();
            try
            {
                var result = await _service.Get(p => p.Id == request.Id);
                if (result == null)
                {
                    return null;
                }
                response.Data = result;
                _logger.LogInformation("Get student from id");
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                _logger.LogError("Throw an exception");
                return response;
            }
        }
    }
}
