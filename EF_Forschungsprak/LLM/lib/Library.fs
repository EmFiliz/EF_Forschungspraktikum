namespace FsLLM

open System
open System.Text
open System.Collections.Generic
open System.Threading.Tasks
open Microsoft.Extensions.AI
open OllamaSharp

type Model =
| Gpt_oss_20B
| Deepseek_r1_8B
| Gemma3_4B
| Embeddinggemma_300M
| Qwen3_8B
| Deepseek_v3_1_671B
| Llama3_1_8B
| Nomic_embed_text_v1_5
| Llama3_2_3B
| Mistral_7B
| Qwen2_5_7B
| Phi3_3_8B
| Llava
| Phi4
| Gemma with 

    static member getModelName m =
        match m with
        | Gptoss -> "gpt-oss:20b"
        | Deepseekr1 -> "deepseek-r1:8b"
        | Gemma3 -> "gemma3:4b"
        | Embeddinggemma -> "embeddinggemma:300m"
        | Qwen3 -> "qwen3:8b"
        | Deepseek_v3_1_671B -> "deepseek-v3.1:671b"
        | Llama3_1_8B -> "llama3.1:8b"
        | Nomic_embed_text_v1_5 ->
        | Llama3_2_3B -> 
        | Mistral_7B -> 
        | Qwen2_5_7B -> 
        | Phi3_3_8B -> 
        | Phi3 -> "phi3:3.8b"
        | Llava -> "llava:7b"
        | Phi4 -> "phi4:14b"
        | Gemma -> "gemma:7b"
    
    static member initClient (m: Model) =
        new OllamaApiClient(new Uri("http://localhost:11434/"), Model.getModelName m)
        :> IChatClient

module Prompt =
    let getResponse (client: IChatClient) (prompt: string) =
        task{
            let messages = [ChatMessage(ChatRole.User, prompt)]
            let! response = client.GetResponseAsync(messages)
            return response
        }
        |> Async.AwaitTask
        |> Async.RunSynchronously

    let getResponseText (client: IChatClient) (prompt: string) = 
        getResponse client prompt
        |> _.ToString()

// open System
// open System.Text
// open System.Collections.Generic
// open System.Threading.Tasks
// open Microsoft.Extensions.AI
// open OllamaSharp

// let chatClient : IChatClient =
//     new OllamaApiClient(new Uri("http://localhost:11434/"), "gpt-oss:20b")

// let chatHistory = List<ChatMessage>()

// let rec chatLoop () =
//     task{
//         Console.WriteLine("\nYour prompt: ")
//         let userPrompt = Console.ReadLine()
//         if String.IsNullOrWhiteSpace(userPrompt) then
//             Console.WriteLine("Please specify your answer!")
//             return! chatLoop()
//         else
//             chatHistory.Add(ChatMessage(ChatRole.User, userPrompt))

//             printf "AI: "
//             let sb = StringBuilder()
//             let enumerator = chatClient.GetStreamingResponseAsync(chatHistory).GetAsyncEnumerator()
//             try
//                 while! enumerator.MoveNextAsync() do
//                     let item = enumerator.Current
//                     if not (String.IsNullOrEmpty(item.Text)) then
//                         Console.Write(item.Text)
//                         sb.Append(item.Text) |> ignore
//                 Console.WriteLine()
//             finally
//                 do enumerator.DisposeAsync() |> ignore

//             chatHistory.Add(ChatMessage(ChatRole.Assistant, sb.ToString()))
//             return! chatLoop()
//     }

// let buildString () =
//     let sb = StringBuilder()
//     sb.Append(Console.ReadLine()) |> ignore
//     Console.WriteLine()
//     sb.ToString()

// let repeatAnswer () =
//     let readAnswer = Console.ReadLine()
//     readAnswer

// let getPrompt () =
//     task{
//         Console.WriteLine("Your Prompt")
//         let input = Console.ReadLine()
//         if String.IsNullOrWhiteSpace(input) then
//             Console.WriteLine("Bitte Text eingeben")
//         else
//             let messages = [ChatMessage(ChatRole.User, input)]
//             let! response = chatClient.GetResponseAsync(messages)
//             Console.WriteLine("AI: " + response.ToString())
//     }
//     |> Async.AwaitTask
//     |> Async.RunSynchronously

// [<EntryPoint>]
// let main _ =
//     getPrompt()
//     0

