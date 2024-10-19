using AutoMapper;
using TasksApi.DTO.TodoTask;

namespace TasksApi.DTO.Mappings
{
    public class TodoTaskMappingProfile : Profile
    {
        public TodoTaskMappingProfile()
        {
            CreateMap<CreateTodoTaskDto, Models.TodoTask>();
            CreateMap<UpdateTodoTaskDto, Models.TodoTask>();
            CreateMap<Models.TodoTask, TodoTaskDto>();
        }
    }
}
