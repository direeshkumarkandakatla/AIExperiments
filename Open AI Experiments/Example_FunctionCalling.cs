using OpenAI;
using OpenAI.Assistants;
using OpenAI.Chat;
using OpenAI.Responses;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Open_AI_Experiments
{
    public class Example_FunctionCalling : Examples
    {

        private readonly ChatClient _client;
        public Example_FunctionCalling()
        {
            _client = new (model: Model, apiKey: ApiKey);
        }
                
        private async Task<string> Get_Weather_Info(float latitude, float longitude, string unit = "fahrenheit")
        {
            // Simulate a function that fetches temperature based on coordinates
            var httpClient = new HttpClient();

            string url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current=temperature_2m&temperature_unit={unit}";

            var response = await httpClient.GetStringAsync(url);

            return response;
        }

        public async Task<string> AskQuestionAsync(string question)
        {
            List<ChatMessage> messages = new List<ChatMessage>
            {
                new UserChatMessage(question)
            };

            ChatTool getweatherinfotool = ChatTool.CreateFunctionTool(
                functionName: nameof(Get_Weather_Info),
                functionDescription: "Retrieve current weather information based on latitude and longitude either fahrenheit or celsius.",
                functionParameters: BinaryData.FromBytes("""
                {
                    "type": "object",
                    "properties": {
                        "latitude": { "type": "number" },
                        "longitude": { "type": "number" },
                        "unit": {
                            "type": "string",
                            "enum": ["celsius", "fahrenheit"],
                            "default": "fahrenheit"
                        }
                    },
                    "required": ["latitude", "longitude", "unit"],
                    "additionalProperties": false
                }
                """u8.ToArray()));

            ChatTool getpullrequestinfo = ChatTool.CreateFunctionTool(
                functionName: nameof(GetPullRequestInfo),
                functionDescription: "Retrieve information about a specific pull request for a given pullrequest number.",
                functionParameters: BinaryData.FromBytes("""
                {
                    "type": "object",
                    "properties": {
                        "pullRequestNumber": { "type": "number" }
                    },
                    "required": ["pullRequestNumber"],
                    "additionalProperties": false
                }
                """u8.ToArray()));

            ChatCompletionOptions options = new ChatCompletionOptions
            {
                Tools = { getweatherinfotool, getpullrequestinfo }
            };

            ChatCompletion chatCompletion = _client.CompleteChat(messages, options);

            if (chatCompletion.FinishReason == ChatFinishReason.ToolCalls)
            {
                var toolcall = chatCompletion.ToolCalls[0];
                messages.Add(new AssistantChatMessage(chatCompletion));

                string result = string.Empty;

                if (toolcall.FunctionName == nameof(GetPullRequestInfo))
                {
                    var prInfo = JsonSerializer.Deserialize<PrInfo>(Encoding.UTF8.GetString(toolcall.FunctionArguments));
                    var pullRequestInfo = GetPullRequestInfo(prInfo.pullRequestNumber);

                    result = JsonSerializer.Serialize(pullRequestInfo);
                }
                else if (toolcall.FunctionName == nameof(Get_Weather_Info))
                {
                    string jsonData = Encoding.UTF8.GetString(toolcall.FunctionArguments);
                    var arguments = JsonSerializer.Deserialize<WeatherRequest>(jsonData);

                    if (!string.IsNullOrEmpty(arguments.unit))
                        result = await Get_Weather_Info(arguments.latitude, arguments.longitude, arguments.unit);
                    else
                        result = await Get_Weather_Info(arguments.latitude, arguments.longitude);
                    
                }
                messages.Add(new ToolChatMessage(toolCallId: toolcall.Id, content: result));
                ChatCompletion finalResponse = _client.CompleteChat(messages, options);
                return finalResponse.Content[0].Text;
            }
            else
            {
                return chatCompletion.Content[0].Text;
            }   
        }

        public object GetPullRequestInfo(int pullRequestNumber)
        {
            // Simulate a function that retrieves pull request information

            var fake_pull_requests = new Dictionary<int, Dictionary<string, object>>
            {
                { 198234, new Dictionary<string, object>
                    {
                        { "title", "Fix bug in user login" },
                        { "status", "open" },
                        { "author", "Alice" },
                        { "reviewers", new List<string> { "Bob", "Charlie" } },
                        { "created_at", "2024-10-01" }
                    }
                },
                { 198237, new Dictionary<string, object>
                    {
                        { "title", "Add new feature for notifications" },
                        { "status", "closed" },
                        { "author", "Bob" },
                        { "reviewers", new List<string> { "Alice" } },
                        { "created_at", "2024-10-02" }
                    }
                },
                { 198235, new Dictionary<string, object>
                    {
                        { "title", "Update documentation" },
                        { "status", "merged" },
                        { "author", "Charlie" },
                        { "reviewers", new List<string> { "Alice", "Bob" } },
                        { "created_at", "2025-07-03" }
                    }
                }
            };

            return fake_pull_requests.TryGetValue(pullRequestNumber, out var pullRequestInfo) 
                ? pullRequestInfo 
                : new Dictionary<string, object> { { "error", "Pull request not found" } };
        }
    }

    public class WeatherRequest
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
        public string unit { get; set; }
    }

    public class PrInfo
    {
        public int pullRequestNumber { get; set; }
    }
}
