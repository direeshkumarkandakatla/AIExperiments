using OpenAI;
using OpenAI.Assistants;
using OpenAI.Chat;
using OpenAI.Responses;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Open_AI_Experiments
{
    public class Example_SimpleChat : Examples
    {

        private readonly ChatClient _client;
        public Example_SimpleChat()
        {
            _client = new (model: Model, apiKey: ApiKey);
        }

        public string AskQuestion(string question)
        {
            ChatCompletion response = _client.CompleteChat(question);

            return response.Content[0].Text;
        }

        public async Task<string> AskQuestionAsync(string question)
        {
            ChatCompletion response = await _client.CompleteChatAsync(question);

            return response.Content[0].Text;
        }
    }
}
