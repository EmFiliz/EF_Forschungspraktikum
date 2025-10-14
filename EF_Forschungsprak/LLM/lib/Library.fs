namespace FSharpLLM

open System
open System.Text
open System.Collections.Generic
open System.Threading.Tasks
open Microsoft.Extensions.AI
open OllamaSharp

module LLM_Modal = 
    type Modal =
    | Gptoss
    | Deepseekr1
    | Gemma3
    | Embeddinggemma
    | Qwen3
    | Llama3
    | Phi3
    | Llava
    | Phi4
    | Gemma

    let modalname m =
        match m with
        | Gptoss -> "gpt-oss:20b"
        | Deepseekr1 -> "deepseek-r1:8b"
        | Gemma3 -> "gemma3:4b"
        | Embeddinggemma -> "embeddinggemma:300m"
        | Qwen3 -> "qwen3:8b"
        | Llama3 -> "llama3.1:8b"
        | Phi3 -> "phi3:3.8b"
        | Llava -> "llava:7b"
        | Phi4 -> "phi4:14b"
        | Gemma -> "gemma:7b"

module LLM =

    type ChatClient (model: LLM_Modal.Modal) =
        let client : IChatClient = new OllamaApiClient(new Uri("http://localhost:11434/"), LLM_Modal.modalname model)

        member _.GetPrompt(prompt: string) =
            let taskResult = task{
                let messages = [ChatMessage(ChatRole.User, prompt)]
                let! response = client.GetResponseAsync(messages :> IEnumerable<ChatMessage>)
                Console.WriteLine("AI: \n" + response.ToString())
            }
            taskResult.GetAwaiter().GetResult()
