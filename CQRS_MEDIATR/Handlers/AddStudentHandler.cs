using AutoMapper;
using CQRS_MEDIATR.Commands;
using CQRS_MEDIATR.Model;
using CQRS_MEDIATR.Model.Dto;
using CQRS_MEDIATR.Services.Abstract.StudentService;


namespace CQRS_MEDIATR.Handlers
{
    public class AddStudentHandler : IRequestHandler<AddStudentCommand, ServiceResponse>
    {
        private IStudentService _service;
        private ILogger<Student> _logger;
        private IMapper _mapper;
        public AddStudentHandler(IStudentService service,ILogger<Student> logger,IMapper mapper)
        {
            _service= service;
            _logger= logger;
            _mapper= mapper;
        }
        public async Task<ServiceResponse> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var response = new ServiceResponse();
            try
            {
                if (request._dto == null)
                {
                    return null;
                }
                var result = _mapper.Map<Student>(request._dto);
                await _service.Add(result);
                _logger.LogInformation("Add student");
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
