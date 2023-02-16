namespace APITestOne;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<NewAgentDto, Agent>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.SurName, opt => opt.MapFrom(src => src.SurName))
            .ForMember(dest => dest.Localization, opt => opt.MapFrom(src => src.Localization))
            .ForMember(dest => dest.FizzBuzz, opt => opt.MapFrom(src => src.FizzBuzz));

        CreateMap<Agent, AgentDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.SurName, opt => opt.MapFrom(src => src.SurName))
            .ForMember(dest => dest.Localization, opt => opt.MapFrom(src => src.Localization));
    }
}
