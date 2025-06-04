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
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName)) // Map FirstName to Name
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.LastName)) // Map LastName to Surname
                .ForMember(dest => dest.ContactNo, opt => opt.MapFrom(src => src.PhoneNumber))// Convert string PhoneNumber to int ContactNo
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.ToLower())) // AutoMapper can handle lowercasing email once
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email.ToLower())) // Set UserName to lowercased email
                .ForMember(dest => dest.NormalizedEmail, opt => opt.MapFrom(src => src.Email.ToUpper())) // Set NormalizedEmail to uppercased email
                .ForMember(dest => dest.NormalizedUserName, opt => opt.MapFrom(src => src.Email.ToUpper())); // Set NormalizedUserName to uppercased email
                // We'll handle PasswordHash and SecurityStamp manually in UserService for security reasons

            // Mapping from User model to DTO (for responses)
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.Name)) // Map Name to Firstname
                .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.Surname)); // Map Surname to Lastname


            // Other mappings (ensure they are correct if you use them elsewhere)
            CreateMap<UserForUpdateDto, User>();
            CreateMap<User, UserForUpdateDto>();
        }
    }
}