open FsLLM
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




[<EntryPoint>]
let main _ = 
    Prompt.getResponseWithChatHistoryInteractive chatHistory (Model.initClient(Model.Gpt_oss_20B)) 
    |> Async.AwaitTask
    |> Async.RunSynchronously
    0
