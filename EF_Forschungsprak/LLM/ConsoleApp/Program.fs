open System
open System.Text
open System.Collections.Generic
open System.Threading.Tasks
open Microsoft.Extensions.AI
open OllamaSharp

let chatClient : IChatClient =
    new OllamaApiClient(new Uri("http://localhost:11434/"), "gpt-oss:20b")

let chatHistory = List<ChatMessage>()

let rec chatLoop () =
    task{
        Console.WriteLine("\nYour prompt: ")
        let userPrompt = Console.ReadLine()
        if String.IsNullOrWhiteSpace(userPrompt) then
            Console.WriteLine("Please specify your answer!")
            return! chatLoop()
        else
            chatHistory.Add(ChatMessage(ChatRole.User, userPrompt))

            printf "AI: "
            let sb = StringBuilder()
            let enumerator = chatClient.GetStreamingResponseAsync(chatHistory).GetAsyncEnumerator()
            try
                while! enumerator.MoveNextAsync() do
                    let item = enumerator.Current
                    if not (String.IsNullOrEmpty(item.Text)) then
                        Console.Write(item.Text)
                        sb.Append(item.Text) |> ignore
                Console.WriteLine()
            finally
                do enumerator.DisposeAsync() |> ignore

            chatHistory.Add(ChatMessage(ChatRole.Assistant, sb.ToString()))
            return! chatLoop()
    }

let buildString () =
    let sb = StringBuilder()
    sb.Append(Console.ReadLine()) |> ignore
    Console.WriteLine()
    sb.ToString()

let repeatAnswer () =
    let readAnswer = Console.ReadLine()
    readAnswer

let getPrompt () =
    task{
        Console.WriteLine("Your Prompt")
        let input = Console.ReadLine()
        if String.IsNullOrWhiteSpace(input) then
            Console.WriteLine("Bitte Text eingeben")
        else
            let messages = [ChatMessage(ChatRole.User, input)]
            let! response = chatClient.GetResponseAsync(messages)
            Console.WriteLine("AI: " + response.ToString())
    }
    |> Async.AwaitTask
    |> Async.RunSynchronously

[<EntryPoint>]
let main _ =
    getPrompt()
    0