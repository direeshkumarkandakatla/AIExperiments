from openai import OpenAI
import os
import json

# Initialize the OpenAI client with the API key from environment variables
client = OpenAI(api_key=os.getenv("OPENAI_API_KEY"))        

def get_employee_info(employee_id):
    """
    Function to retrieve employee information based on the provided employee ID.
    """
    try:
        fake_employee_data = {
            "E120": {"name": "Alice Smith", "position": "Software Engineer", "department": "Engineering"},
            "E230": {"name": "Bob Johnson", "position": "Product Manager", "department": "Product"},
            "E340": {"name": "Charlie Brown", "position": "Data Scientist", "department": "Data Science"},
            "E450": {"name": "Diana Prince", "position": "UX Designer", "department": "Design"},
            "E560": {"name": "Ethan Hunt", "position": "DevOps Engineer", "department": "Operations"}
        }
        
        return fake_employee_data.get(employee_id, {"error": "Employee not found"})
    
    except Exception as e:
        return json.dumps({"error": str(e)})
    
emp_function_call = {
    "type": "function",
    "name": "get_employee_info",
    "description": "Retrieve information about an employee by their ID. Ex: E120, E230, etc.",
    "parameters": {
        "type": "object",
        "properties": {
            "employee_id": {
                "type": "string",
                "description": "The unique identifier for the employee."
            }
        },
        "required": ["employee_id"],
        "additionalProperties": False
    }
}

user_message = { 
    "role": "user",
    "content": "Can you provide information about employee E340?"
}

response = client.responses.create(
    model="gpt-4.1",
    input=[user_message],
    tools=[emp_function_call],
    tool_choice="auto"
)

# print(response)

print(f"model response:")
print(response.model)

function_call = response.output[0];
function_name = function_call.name

arguments = json.loads(function_call.arguments)

print(f"model wants to call function: {function_name}")
print(f"with arguments: {arguments}")

if (function_name == "get_employee_info"):
    employee_info = get_employee_info(arguments["employee_id"])
    
    follow_up_message = client.responses.create(
        model="gpt-4.1",
        input = [user_message, function_call, {
            "type": "function_call_output",
            "call_id": function_call.call_id,
            "output": json.dumps(employee_info)
        }],
        tools=[emp_function_call],  
    )

    print(f"follow-up response: {follow_up_message.output_text}")

print("End of script.")


