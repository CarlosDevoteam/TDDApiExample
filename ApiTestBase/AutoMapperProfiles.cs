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
            .ForMember(dest => dest.Localization, opt => opt.MapFrom(src => src.Localization))
            .ForMember(dest => dest.FizzBuzzValue, opt => opt.MapFrom(src => GetFizzBuzz(src.FizzBuzz)));
    }
    private string GetFizzBuzz(int value)
    {
        if (value % 3 == 0 && value % 5 == 0)
            return "FizzBuzz";
        if (value % 3 == 0)
            return "Fizz";
        if (value % 5 == 0)
            return "Buzz";
        return value.ToString();
    }

}
