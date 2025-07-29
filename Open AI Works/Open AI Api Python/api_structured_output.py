from openai import OpenAI
import os
import json

client = OpenAI(api_key = os.getenv("OPENAI_API_KEY"))

# Define our function schema
functions = [
    {
        "name": "get_planets_info",
        "description": "Get information about all planets in the solar system",
        "parameters": {
            "type": "object",
            "properties": {
                "planets": {
                    "type": "array",
                    "items": {
                        "type": "object",
                        "properties": {
                            "name": {
                                "type": "string",
                                "description": "Name of the planet"
                            },
                            "size": {
                                "type": "number",
                                "description": "Size of the planet in kilometers (diameter)"
                            },
                            "color": {
                                "type": "string",
                                "description": "Color of the planet"
                            },
                            "distance": {
                                "type": "number",
                                "description": "Distance from the sun in million kilometers"
                            }
                        },
                        "required": ["name", "size", "color", "distance"]
                    }
                }
            },
            "required": ["planets"]
        }
    }
]

try:
    response = client.chat.completions.create(
        model="gpt-4",
        messages=[
            {
                "role": "system",
                "content": "You are a helpful assistant that provides accurate astronomical data about planets in our solar system."
            },
            {
                "role": "user",
                "content": "Can you provide detailed information about the planets in our solar system?"
            }
        ],
        functions=functions,
        function_call={"name": "get_planets_info"}
    )

    # Extract and parse the function call response
    function_response = json.loads(response.choices[0].message.function_call.arguments)
    print(response);
    
except Exception as e:
    print(f"An error occurred: {e}")
