using System.Text.Json.Serialization;

namespace APITestBase.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AgentType
{
    FirstClass = 1,
    SecondeClass = 2,
    ThrirdClass = 3
}