using CQRS_MEDIATR.Commands;
using CQRS_MEDIATR.Model;
using CQRS_MEDIATR.Services.Abstract.StudentService;

namespace CQRS_MEDIATR.Handlers
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, ServiceResponse>
    {
        private IStudentService _service;
        private ILogger<Student> _logger;
        public DeleteStudentHandler(IStudentService service, ILogger<Student> logger)
        {
            _service = service;
            _logger = logger;
        }
        public async Task<ServiceResponse> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var response = new ServiceResponse();
            try
            {
                var result = await _service.Get(p => p.Id == request.Id);

                if (result == null)
                {
                    response.Message = "there is no existing data";
                    return response;
                }

                await _service.Delete(result);
                _logger.LogInformation("Delete student");
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
