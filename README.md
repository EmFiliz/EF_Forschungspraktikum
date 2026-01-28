# FsLLM: A Simple F# Wrapper for the OllamaApi

## Getting started

To use FsLLM, ensure you have [Ollama][https://ollama.com/] installed and running on your local machine.

---

## Installation & Setup

Use `dotnet build` to compile the library. Ensure you are executing the command in the project's root directory.

### Using Polyglot Notebooks

If you are using Polyglot Notebooks, use the following snippet to load the library and its dependencies:

---

```fsharp
#load "./Library.fs"
#r "nuget: OllamaSharp, 5.4.13"
#r "nuget: Microsoft.Extensions.AI, 10.2.0"

open FsLLM
```


## Core Functions

### Initializing the Client

```fsharp
let client = 
    Model.initClient(Model.Gemma3_4B)
    |> Async.AwaitTask
    |> Async.RunSynchronously
```

The `initClient` method checks whether the selected model is installed locally. If it is missing, the method will automatically download (pull) it. To use the API, a client must be initialized. Note that a client is bound to one specific model at a time.


### Basic Usage

```fsharp
// Initialize with default parameters
let optionsDefault : Prompt.LLMChatOptions = Prompt.LLMChatOptions.init()

// Initialize with custom parameters
let optionsUser : Prompt.LLMChatOptions =
    Prompt.LLMChatOptions.init(
        Temperature = 1.0
    )
let response = Prompt.getResponseText client options "Hello, how are you?"
```

---

### Chat History (Stateful Conversations)

The `chatHistory` object is a mutable list. Once initialized, it tracks the conversation flow.

```fsharp
let chatHistory = Prompt.initChatHistory()

let response = Prompt.getResponseWithChatHistoryText client options chatHistory "How are you doing?"

```

---

### Utilities

**Save ChatHistory as Markdown file**

Export your conversation to a Markdown file:

```fsharp
Prompt.saveChatHistoryAsMarkdownFile "test.md" client chatHistory options
```

**Manage Models**

```fsharp
// List all models
Models.listModels(client)

// Unload model immediately
Models.unloadModel(client)

// Set a custom keep-alive time
Models.unloadModelAfterTime client "10s"
```

**Note**: By default, Ollama keeps models in memory for 5 minutes. `unloadModelAfterTime` accepts a string convention: e.g. `1s` (1 second), `1m` (1 minute), or `1h` (1 hour).















