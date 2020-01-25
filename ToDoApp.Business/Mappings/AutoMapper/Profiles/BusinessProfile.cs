using AutoMapper;
using ToDoApp.DataDomain.Dto;
using ToDoApp.Entities.EntityFramework;

namespace ToDoApp.Business.Mappings.AutoMapper.Profiles
{
    public class BusinessProfile: Profile
    {
        public BusinessProfile()
        {
            //CreateMap<Tasks, TaskDto>();
        }
    }
}
