using api.Dto;
using AutoMapper;


namespace api.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping from DTO to User model
            CreateMap<UserForCreateDto, User>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.LastName)) 
                .ForMember(dest => dest.ContactNo, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.ToLower()))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email.ToLower()))
                .ForMember(dest => dest.NormalizedEmail, opt => opt.MapFrom(src => src.Email.ToUpper()))
                .ForMember(dest => dest.NormalizedUserName, opt => opt.MapFrom(src => src.Email.ToUpper()));
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.Name)) 
                .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.Surname));
            CreateMap<UserForUpdateDto, User>();
            CreateMap<User, UserForUpdateDto>();
        }
    }
}