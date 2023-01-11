using AutoMapper;
using CQRS_MEDIATR.Commands;
using CQRS_MEDIATR.Model;
using CQRS_MEDIATR.Model.Dto;
using CQRS_MEDIATR.Services.Abstract.StudentService;
using MediatR;

namespace CQRS_MEDIATR.Handlers
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, ServiceResponse>
    {
        private IStudentService _service;
        private ILogger<Student> _logger;
        private IMapper _mapper;
        public UpdateStudentHandler(IStudentService service, ILogger<Student> logger,IMapper mapper)
        {
            _service= service;
            _logger= logger;
            _mapper= mapper;
        }
        public async Task<ServiceResponse> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var response = new ServiceResponse();
            try
            {
                if (request.Id != request._dto.Id || request._dto == null)
                {
                    response.Message = "updating is wrong";
                    return response;
                }
                var result = _mapper.Map<Student>(request._dto);

                if (result == null)
                {
                    response.Message = "mapping is not happened";
                    return response;
                }

                await _service.Update(result);
                _logger.LogInformation("Update student");
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
