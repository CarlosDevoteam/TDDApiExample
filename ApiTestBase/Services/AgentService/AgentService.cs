
using APITestBase.Services.SQLService;

namespace APITestBase.Services.AgentService;

public class AgentService : IAgentService
{
    private readonly ILogger<AgentService> _ilogger;
    private readonly IMapper _mapper;
    private readonly ISQLService _sqlService;

    public AgentService(ILogger<AgentService> logger, ISQLService sqlService, IMapper mapper )
    {
        _ilogger = logger;
        _sqlService = sqlService;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<AgentDto>> GetAgentFizzBuzz(int id)
    {
        var serviceResponse = new ServiceResponse<AgentDto>();
        try
        {
            Agent agent = await _sqlService.GetAgentById(id);
           
            AgentDto agentDto = _mapper.Map<AgentDto>(agent);
            serviceResponse.Data = agentDto;
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<AgentDto>>> GetAllAgents()
    {
        var serviceResponse = new ServiceResponse<List<AgentDto>>();
        try
        {
            List<Agent> agents = await _sqlService.GetAllAgents();
            serviceResponse.Data = _mapper.Map<List<AgentDto>>(agents);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<AgentDto>> GetAgent(int id)
    {
        var serviceResponse = new ServiceResponse<AgentDto>();
        try
        {
            Agent agent = await _sqlService.GetAgentById(id);
            serviceResponse.Data = _mapper.Map<AgentDto>(agent);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<AgentDto>> AddAgent(NewAgentDto newAgentDto)
    {
        var serviceResponse = new ServiceResponse<AgentDto>();
        try
        {
            Agent newAgent = _mapper.Map<Agent>(newAgentDto);
            await _sqlService.AddAgent(newAgent);
            Agent agent = await _sqlService.GetAgentByName(newAgent.Name);
            serviceResponse.Data = _mapper.Map<AgentDto>(agent);
        }
        catch(Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }
}
