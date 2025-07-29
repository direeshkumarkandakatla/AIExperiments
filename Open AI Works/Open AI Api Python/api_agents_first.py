from agents import (
    Agent,
    Runner,
    RunConfig,
    set_default_openai_key,
    function_tool
) 
import os

set_default_openai_key(os.environ.get("OPENAI_API_KEY"))

@function_tool
def calculate_tip(bill_amount: float, tip_percentage: float) -> str:
    """
    Calculate the tip based on the bill amount and tip percentage.
    
    Args:
        bill_amount (float): The total bill amount.
        tip_percentage (float): The percentage of the bill to be given as a tip.
        
    Returns:
        string: The calculated tip amount.
    """
    tip_amount = round(bill_amount * (tip_percentage / 100), 2)
    total_amount = bill_amount + tip_amount

    result = f"The tip is ${tip_amount} and the total amount to be paid is ${total_amount}."

    print(f"Calculated total amount: {result}")

    return result

restaurant_agent = Agent(
    name="RestaurantAgent",
    instructions="An agent that can calculate tips based on bill amounts and tip percentages.",
    tools=[calculate_tip],
    model="gpt-4.1"
)

config = RunConfig(tracing_disabled=True, trace_include_sensitive_data=False)

result = Runner.run_sync(
    starting_agent=restaurant_agent,
    input="I had a bill of $50 and I want to give a tip of 20%. How much should I tip?",
    run_config=config)

print(f"Agent response: {result.final_output}")
print(f"Guard rail:{result.output_guardrail_results}")
