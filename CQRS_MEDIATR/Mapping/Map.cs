using AutoMapper;
using CQRS_MEDIATR.Model;
using CQRS_MEDIATR.Model.Dto;

namespace CQRS_MEDIATR.Mapping
{
    public class Map:Profile
    {
        public Map() {
            CreateMap<StudentCreateDto,Student>().ReverseMap();
            CreateMap<StudentUpdateDto, Student>().ReverseMap();
        }
    }
}
