using Microsoft.AspNetCore.Mvc;

namespace APITestBase.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AgentsController : ControllerBase
{
    public readonly IAgentService _agentService;
    public AgentsController(IAgentService agentService)
    {
        _agentService = agentService;
    }

    [HttpGet("AllAgents")]
    public async Task<ActionResult<ServiceResponse<List<AgentDto>>>> GetAllAgents()
    {
        return Ok(await _agentService.GetAllAgents());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<AgentDto>>> GetAgent(int id)
    {
        return Ok(await _agentService.GetAgent(id));
    }
    
    [HttpGet("FizzBuzz/{id}")]
    public async Task<ActionResult<ServiceResponse<AgentDto>>> GetFizzBuzz(int id)
    {
        return Ok(await _agentService.GetAgentFizzBuzz(id));
    }

    [HttpPost]
    public async Task<ActionResult<List<Agent>>> AddAgent(NewAgentDto newAgent)
    {
        return Ok(await _agentService.AddAgent(newAgent));

    }
}