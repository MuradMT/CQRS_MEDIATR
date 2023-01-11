using Azure;
using CQRS_MEDIATR.Model;
using CQRS_MEDIATR.Queries;
using CQRS_MEDIATR.Services.Abstract.StudentService;
using Microsoft.Extensions.Logging;

namespace CQRS_MEDIATR.Handlers
{
    public class GetStudentsHandler : IRequestHandler<GetStudentsQuery, ServiceResponse>
    {
        private IStudentService _service;
        private ILogger<Student> _logger;
        public GetStudentsHandler(IStudentService service, ILogger<Student> logger)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<ServiceResponse> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var response = new ServiceResponse();
            try
            {
                var result = await _service.GetAll();
                if (result == null)
                {
                    return null;
                }
                response.Data = result;
                _logger.LogInformation("Get students");
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
