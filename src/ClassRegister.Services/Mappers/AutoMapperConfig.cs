using System;
using System.Threading.Tasks;
using AutoMapper;
using ClassRegister.Core.Model;
using ClassRegister.Core.Repositories;
using ClassRegister.Services.DTOs;

namespace ClassRegister.Services.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentDto>()
                    .ForMember(x => x.Address,
                        m => m.MapFrom(
                            p => p.Street + ' ' + p.HouseNumber + '\n' + p.PostCode + ' ' + p.City))
                    .ForMember(x => x.Id, o => o.Ignore());
                cfg.CreateMap<Teacher, TeacherDto>()
                    .ForMember(x => x.Address,
                        m => m.MapFrom(
                            p => p.Street + ' ' + p.HouseNumber + '\n' + p.PostCode + ' ' + p.City))
                    .ForMember(x => x.Id, o => o.Ignore());
                cfg.CreateMap<Parent, ParentDto>()
                    .ForMember(x => x.Address,
                        m => m.MapFrom(
                            p => p.Street + ' ' + p.HouseNumber + '\n' + p.PostCode + ' ' + p.City))
                    .ForMember(x => x.Id, o => o.Ignore());
                cfg.CreateMap<Admin, AdminDto>()
                    .ForMember(x => x.Address,
                        m => m.MapFrom(
                            p => p.Street + ' ' + p.HouseNumber + '\n' + p.PostCode + ' ' + p.City))
                    .ForMember(x => x.Id, o => o.Ignore());
                cfg.CreateMap<Teacher, TeacherToGroupDto>();
            }).CreateMapper();
        }
    }
}