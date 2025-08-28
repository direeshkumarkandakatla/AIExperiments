from agents import Agent, Runner

agent = Agent(
    name="Math Tutorial Agent",
    description="You provide step-by-step explanations for solving math problems."
)

history_tutor_agent = Agent(
    name="History Tutor Agent",
    description="You provide detailed explanations and insights into historical events."
)

math_tutor_agent = Agent(
    name="Math Tutor Agent",
    description="You provide step-by-step explanations for solving math problems."
)

triage_agent = Agent(
    name="Triage Agent",
    description="You determine which agent is best suited to handle a user's request based on the content of the request.",
    handoffs=[history_tutor_agent, math_tutor_agent]
)

async def main():
    result = await Runner.run(triage_agent, "Explain the causes of World War II.")
    print(f"Result: {result.final_output}")
