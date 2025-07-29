// See https://aka.ms/new-console-template for more information
using Open_AI_Experiments;


//var simpleChat = new Example_SimpleChat();

//var response1 = simpleChat.AskQuestion("What is the capital city of Telangana state in India ?");

//var response2 = await simpleChat.AskQuestionAsync("Can you please get the co-ordinates of Atmakur mandal in Warangal district, Telangana, India ?");

//Console.WriteLine($"Response 1: {response1}");
//Console.WriteLine($"Response 2: {response2}");

var functionCalling = new Example_FunctionCalling();

while(true)
{
    Console.WriteLine("Enter your question (or type 'exit' to quit):");
    string userInput = Console.ReadLine();
    
    if (userInput?.ToLower() == "exit")
        break;

    var response = await functionCalling.AskQuestionAsync(userInput);
    Console.WriteLine($"Response: {response}");
}

Console.ReadLine();