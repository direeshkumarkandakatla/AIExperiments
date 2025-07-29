from openai import OpenAI
import os

# Initialize the OpenAI client with the API key from environment variables
client = OpenAI(api_key=os.getenv("OPENAI_API_KEY"))   

conversation = [{ "role": "system", "content": "You are kind of google or wikipedia, answer user questions" }]

conversation.append({"role": "user", "content": "what is the capital of France? "})

# Create a response using the OpenAI client
response = client.responses.create(
    model="gpt-4.1",
    input=conversation)

print(f"turn 1: {response.output_text}")

conversation.append({"role": "user", "content": "and population?"})

response1 = client.responses.create(
    model="gpt-4.1",
    input= conversation)

print(f"turn 2: {response1.output_text}");