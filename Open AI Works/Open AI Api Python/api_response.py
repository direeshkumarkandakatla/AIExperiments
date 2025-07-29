from openai import OpenAI
import os

# print(os.environ.get("OPENAI_API_KEY"))
# print(os.getenv("OPENAI_API_KEY"))

client = OpenAI(api_key = os.getenv("OPENAI_API_KEY"))

#prompttext = "Prepare OOF message for sick leave for a week, starting from tomorrow. I will be unavailable for work during this period.";

inputtext = [
    {
        "role": "developer",
        "content": "You are a creative poet writes poems in response to user requests. Your poems should be engaging, imaginative, and tailored to the user's request."
    },
    {
        "role": "user",
        "content": "Create a poem about the beauty of having daughter and a young son, capturing the joy and challenges of parenthood."
    }
]

response = client.responses.create(
    model="gpt-4.1",
    temperature=2,
    input= inputtext)

print(response.output_text)