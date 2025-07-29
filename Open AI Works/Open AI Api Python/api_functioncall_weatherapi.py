from openai import OpenAI
import os
import json
import requests

# Initialize the OpenAI client with the API key from environment variables
client = OpenAI(api_key=os.getenv("OPENAI_API_KEY"))    

def get_weather_info(latitude, longitude, unit="fahrenheit"):
    """
    Function to retrieve weather information based on latitude and longitude.
    """
    try:
        # Simulated weather data
        api_url = f"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current=temperature_2m&temperature_unit={unit}"
        print(f"Fetching weather data from: {api_url}")
        response = requests.get(api_url)

        print(f"Weather API response: {response.text}")

        data = response.json()
        return data['current']['temperature_2m']
    
    except Exception as e:
        print(f"Error retrieving weather data: {e}")
        return json.dumps({"error": str(e)})

def get_pullrequest_info(pullrequestid):
    """
    Function to retrieve pull request information based on the provided ID.
    """
    try:
        # Simulated pull request data
        fake_pull_requests = {
            198234: {"title": "Fix bug in user login", "status": "open", "author": "Alice", "reviewers": ["Bob", "Charlie"], "created_at": "2024-10-01"},
            198237: {"title": "Add new feature for notifications", "status": "closed", "author": "Bob", "reviewers": ["Alice"], "created_at": "2024-10-02"},
            198235: {"title": "Update documentation", "status": "merged", "author": "Charlie", "reviewers": ["Alice", "Bob"], "created_at": "2025-07-03"}
        }
        
        return fake_pull_requests.get(pullrequestid, {"error": "Pull request not found"})
    
    except Exception as e:
        return json.dumps({"error": str(e)})    

tools = [{
    "type": "function",
    "name": "get_weather_info",
    "description": "Retrieve current weather information based on latitude and longitude either fahrenheit or celsius.",
    "parameters": {
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
        "additionalProperties": False
    },
    "strict": True
    },
    # {
    #     "type": "web_search_preview",
    #     "user_location": {
    #         "type": "approximate",
    #         "city": "Warangal",            
    #         "country": "IN"
    #     }
    # },
    {
        "type": "function",
        "name": "get_pullrequest_info",
        "description": "Retrieve information about a pull request by its ID.",
        "parameters": {
            "type": "object",
            "properties": {
                "pullrequestid": { "type": "number" }
            },
            "required": ["pullrequestid"],
            "additionalProperties": False
        }
    }]

input_messages = [{
    "role": "user",
    "content": "What is the current weather in Bellevue, WA, USA ? Please provide the temperature in fahrenheit."
}]

response = client.responses.create(
    model="gpt-4.1",    
    input=input_messages,
    tools=tools)
toolcall = response.output[0]

print(f"Model response first:")
print(toolcall.type)

if (toolcall.type == "function_call"):
    print(f"Function call detected: {toolcall.name}")
    print(f"Arguments: {toolcall.arguments}")
    # Extract latitude and longitude from the tool call arguments
    args = json.loads(toolcall.arguments)

    if toolcall.name == "get_weather_info":
        if 'unit' in args:
            result = get_weather_info(args['latitude'], args['longitude'], args['unit'])
        else: 
            result = get_weather_info(args['latitude'], args['longitude'])

        print(f"Weather info result: {result}")
    elif toolcall.name == "get_pullrequest_info":
        result = get_pullrequest_info(args['pullrequestid'])
        print(f"Pull request info result: {result}")

    input_messages.append(toolcall);

    input_messages.append({
        "type": "function_call_output",
        "call_id": toolcall.call_id,
        "output": str(result)
    });

    response2 = client.responses.create(
        model="gpt-4.1",
        input=input_messages,
        tools=tools
    )

    print(f"Model response after function call:")
    print(response2.output_text)
elif toolcall.type == "web_search_call":
    print("Web search preview detected.")
    print(f"toolcall: {toolcall}")

    print(response.output_text)
else:
    print("No function call or web search detected in the model response.")
    print(response.output_text)

