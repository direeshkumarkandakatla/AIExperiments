from openai import OpenAI
import os   
import json

# Initialize the OpenAI client with the API key from environment variables
client = OpenAI(api_key=os.getenv("OPENAI_API_KEY"))    

response = client.responses.create(
    model="gpt-4.1",
    input=[{"role": "user", "content": "What are the latest news on weather"}],
    tools=[{
        "type": "web_search_preview",
        "user_location": {
            "type": "approximate",
            "city": "Seattle, Washington",
            "country": "US"
        },
        "search_context_size": "low"
    }]
)

print(response.output_text)

