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
| Llava_7B
| Llama3_8B
| Gemma2_9B
| Qwen2_5_coder_7B
| Phi4_14B
| Gemma_7B
| Mxbai_embed_large_335M
| Qwen_4B
| Qwen2_7B
| Llama2_7B
| Minicpm_v_8B
| Dolphin3_8B
| Codellama_7B
| Olmo2_7B
| Tinyllama_1_1B
| Mistral_nemo_12B
| Llama3_2_vision_11B
| Llama3_3_70B
| Deepseek_v3_671B
| Bge_m3_567M
| Mistral_small_24B
| Smollm2_1_7B
| Llava_llama3_8B
| All_minilm_22M
| Qwq_32B
| Deepseek_coder_1_3B
| Mixtral_8x7B
| Starcoder2_3B
| Llama2_uncensored_7B
| Codegemma_7B
| Deepseek_coder_v2_16B
| Snowflake_arctic_embed_335M
| Falcon3_7B
| Granite3_1_moe_3B
| Orca_mini_3B
| Qwen2_5vl_7B
| Llama4_16x17B
| Phi_2_7B
| Dolphin_mixtral_8x7B
| Mistral_small3_2_24B
| Granite3_3_8B
| Openthinker_7B
| Cogito_8B
| Gemma3n_e4B
| Phi4_reasoning_14B
| Magistral_24B
| Deepscaler_1_5B
| Qwen3_coder_30B
| Dolphin_phi_2_7B
| Dolphin_llama3_8B
| Codestral_22B
| Smollm_1_7B
| Wizardlm2_7B
| Phi4_mini_3_8B
| Dolphin_mistral_7B
| Devstral_24B
| Granite3_2_vision_2B
| Command_r_35B
| Hermes3_8B
| Phi3_5_3_8B
| Deepcoder_14B
| Mistral_small3_1_24B
| Yi_6B
| Zephyr_7B
| Granite_code_3B
| Moondream_1_8B
| Mistral_large_123B
| Wizard_vicuna_uncensored_7B
| Starcoder_3B
| Deepseek_llm_7B
| Nous_hermes_7B
| Vicuna_7B
| Exaone_deep_7_8B
| Openchat_7B
| Falcon_7B
| Deepseek_v2_16B
| Mistral_openorca_7B
| Codegeex4_9B
| Openhermes_v2_5
| Codeqwen_7B
| Opencoder_8B
| Snowflake_arctic_embed2_568M
| Qwen2_math_7B
| Llama2_chinese_7B
| Aya_8B
| Tinydolphin_1_1B
| Glm4_9B
| Granite3_2_8B
| Stable_code_3B
| Nous_hermes2_10_7B
| Neural_chat_7B
| Wizardcoder_33B
| Command_r_plus_104B
| Bakllava_7B
| Sqlcoder_7B
| Bge_large_335M
| Stablelm2_1_6B
| Yi_coder_9B
| Llama3_chatqa_8B
| Llava_phi3_3_8B
| Granite3_dense_2B
| Granite3_1_dense_8B
| Wizard_math_7B
| Reflection_70B
| Exaone3_5_7_8B
| Llama3_gradient_8B
| R1_1776_70B
| Dbrx_132B
| Dolphincoder_7B
| Samantha_mistral_7B
| Paraphrase_multilingual_278M
| Nemotron_mini_4B
| Tulu3_8B
| Granite_embedding_30M
| Starling_lm_7B
| Phind_codellama_34B
| Internlm2_7B
| Solar_10_7B
| Xwinlm_7B
| Athene_v2_72B
| Llama3_groq_tool_use_8B
| Nemotron_70B
| Yarn_llama2_7B
| Meditron_7B
| Granite3_moe_1B
| Wizardlm_uncensored_13B
| Llama_guard3_8B
| Aya_expanse_8B
| Smallthinker_3B
| Orca2_7B
| Wizardlm_70B_llama2_q8_0
| Medllama2_7B
| Nous_hermes2_mixtral_8x7B
| Stable_beluga_7B
| Deepseek_v2_5_236B
| Reader_lm_1_5B
| Command_r7b_7B
| Phi4_mini_reasoning_3_8B
| Llama_pro_instruct
| Shieldgemma_9B
| Yarn_mistral_7B
| Command_a_111B
| Mathstral_7B
| Nexusraven_13B
| Everythinglm_13B
| Codeup_13B
| Marco_o1_7B
| Stablelm_zephyr_3B
| Solar_pro_22B
| Qwen3_embedding_8B
| Duckdb_nsql_7B
| Falcon2_11B
| Magicoder_7B
| Mistrallite_7B
| Codebooga_34B
| Bespoke_minicheck_7B
| Nuextract_3_8B
| Wizard_vicuna_13B
| Granite3_guardian_2B
| Megadolphin_120B
| Notux_8x7B
| Open_orca_platypus2_13B
| Notus_7B
| Sailor2_8B
| Firefunction_v2_70B
| Goliath_120B_fp16
| Granite4_micro
| Alfred_40B
| Command_r7b_arabic_7B
| Kimi_k2_1T_cloud with 

    static member getModelName m =
        match m with
        | Gpt_oss_20B -> "gpt-oss:20b"
        | Deepseek_r1_8B -> "deepseek-r1:8b"
        | Gemma3_4B -> "gemma3:4b"
        | Embeddinggemma_300M -> "embeddinggemma:300m"
        | Qwen3_8B -> "qwen3:8b"
        | Deepseek_v3_1_671B -> "deepseek-v3.1:671b"
        | Llama3_1_8B -> "llama3.1:8b"
        | Nomic_embed_text_v1_5 -> "nomic-embed-text:v1.5"
        | Llama3_2_3B -> "llama3.2:3b"
        | Mistral_7B -> "mistral:7b"
        | Qwen2_5_7B -> "qwen2.5:7b"
        | Phi3_3_8B -> "phi3:latest"
        | Llava_7B -> "llava:7b"
        | Llama3_8B -> "llama3:8b"
        | Gemma2_9B -> "gemma2:9b"
        | Qwen2_5_coder_7B -> "qwen2.5-coder:7b"
        | Phi4_14B -> "phi4:14b"
        | Gemma_7B -> "gemma:7b"
        | Mxbai_embed_large_335M -> "mxbai-embed-large:335m"
        | Qwen_4B -> "qwen:4b"
        | Qwen2_7B -> "qwen2:7b"
        | Llama2_7B -> "llama2:7b"
        | Minicpm_v_8B -> "minicpm-v:8b"
        | Dolphin3_8B -> "dolphin3:8b"
        | Codellama_7B -> "codellama:7b"
        | Olmo2_7B -> "olmo2:7b"
        | Tinyllama_1_1B -> "tinyllama:1.1b"
        | Mistral_nemo_12B -> "mistral-nemo:12b"
        | Llama3_2_vision_11B -> "llama3.2-vision:11b"
        | Llama3_3_70B -> "llama3.3:70b"
        | Deepseek_v3_671B -> "deepseek-v3:671b"
        | Bge_m3_567M -> "bge-m3:567m"
        | Mistral_small_24B -> "mistral-small:24b"
        | Smollm2_1_7B -> "smollm2:1.7b"
        | Llava_llama3_8B -> "llava-llama3:8b"
        | All_minilm_22M -> "all-minilm:22m"
        | Qwq_32B -> "qwq:32b"
        | Deepseek_coder_1_3B -> "deepseek-coder:1.3b"
        | Mixtral_8x7B -> "mixtral:8x7b"
        | Starcoder2_3B -> "starcoder2:3b"
        | Llama2_uncensored_7B -> "llama2-uncensored:7b"
        | Codegemma_7B -> "codegemma:7b"
        | Deepseek_coder_v2_16B -> "deepseek-coder-v2:16b"
        | Snowflake_arctic_embed_335M -> "snowflake-arctic-embed:335m"
        | Falcon3_7B -> "falcon3:7b"
        | Granite3_1_moe_3B -> "granite3.1-moe:3b"
        | Orca_mini_3B -> "orca-mini:3b"
        | Qwen2_5vl_7B -> "qwen2.5vl:7b"
        | Llama4_16x17B -> "llama4:16x17b"
        | Phi_2_7B -> "phi:2.7b"
        | Dolphin_mixtral_8x7B -> "dolphin-mixtral:8x7b"
        | Mistral_small3_2_24B -> "mistral-small3.2:24b"
        | Granite3_3_8B -> "granite3.3:8b"
        | Openthinker_7B -> "openthinker:7b"
        | Cogito_8B -> "cogito:8b"
        | Gemma3n_e4B -> "gemma3n:e4b"
        | Phi4_reasoning_14B -> "phi4-reasoning:14b"
        | Magistral_24B -> "magistral:24b"
        | Deepscaler_1_5B -> "deepscaler:1.5b"
        | Qwen3_coder_30B -> "qwen3-coder:30b"
        | Dolphin_phi_2_7B -> "dolphin-phi:2.7b"
        | Dolphin_llama3_8B -> "dolphin-llama3:8b"
        | Codestral_22B -> "codestral:22b"
        | Smollm_1_7B -> "smollm:1.7b"
        | Wizardlm2_7B -> "wizardlm2:7b"
        | Phi4_mini_3_8B -> "phi4-mini:3.8b"
        | Dolphin_mistral_7B -> "dolphin-mistral:7b"
        | Devstral_24B -> "devstral:24b"
        | Granite3_2_vision_2B -> "granite3.2-vision:2b"
        | Command_r_35B -> "command-r:35b"
        | Hermes3_8B -> "hermes3:8b"
        | Phi3_5_3_8B -> "phi3.5:3.8b"
        | Deepcoder_14B -> "deepcoder:14b"
        | Mistral_small3_1_24B -> "mistral-small3.1:24b"
        | Yi_6B -> "yi:6b"
        | Zephyr_7B -> "zephyr:7b"
        | Granite_code_3B -> "granite-code:3b"
        | Moondream_1_8B -> "moondream:1.8b"
        | Mistral_large_123B -> "mistral-large:123b"
        | Wizard_vicuna_uncensored_7B -> "wizard-vicuna-uncensored:7b"
        | Starcoder_3B -> "starcoder:3b"
        | Deepseek_llm_7B -> "deepseek-llm:7b"
        | Nous_hermes_7B -> "nous-hermes:7b"
        | Vicuna_7B -> "vicuna:7b"
        | Exaone_deep_7_8B -> "exaone-deep:7.8b"
        | Openchat_7B -> "openchat:7b"
        | Falcon_7B -> "falcon:7b"
        | Deepseek_v2_16B -> "deepseek-v2:16b"
        | Mistral_openorca_7B -> "mistral-openorca:7b"
        | Codegeex4_9B -> "codegeex4:9b"
        | Openhermes_v2_5 -> "openhermes:v2.5"
        | Codeqwen_7B -> "codeqwen:7b"
        | Opencoder_8B -> "opencoder:8b"
        | Snowflake_arctic_embed2_568M -> "snowflake-arctic-embed2:568m"
        | Qwen2_math_7B -> "qwen2-math:7b"
        | Llama2_chinese_7B -> "llama2-chinese:7b"
        | Aya_8B -> "aya:8b"
        | Tinydolphin_1_1B -> "tinydolphin:1.1b"
        | Glm4_9B -> "glm4:9b"
        | Granite3_2_8B -> "granite3.2:8b"
        | Stable_code_3B -> "stable-code:3b"
        | Nous_hermes2_10_7B -> "nous-hermes2:10.7b"
        | Neural_chat_7B -> "neural-chat:7b"
        | Wizardcoder_33B -> "wizardcoder:33b"
        | Command_r_plus_104B -> "command-r-plus:104b"
        | Bakllava_7B -> "bakllava:7b"
        | Sqlcoder_7B -> "sqlcoder:7b"
        | Bge_large_335M -> "bge-large:335m"
        | Stablelm2_1_6B -> "stablelm2:1.6b"
        | Yi_coder_9B -> "yi-coder:9b"
        | Llama3_chatqa_8B -> "llama3-chatqa:8b"
        | Llava_phi3_3_8B -> "llava-phi3:3.8b"
        | Granite3_dense_2B -> "granite3-dense:2b"
        | Granite3_1_dense_8B -> "granite3.1-dense:8b"
        | Wizard_math_7B -> "wizard-math:7b"
        | Reflection_70B -> "reflection:70b"
        | Exaone3_5_7_8B -> "exaone3.5:7.8b"
        | Llama3_gradient_8B -> "llama3-gradient:8b"
        | R1_1776_70B -> "r1-1776:70b"
        | Dbrx_132B -> "dbrx:132b"
        | Dolphincoder_7B -> "dolphincoder:7b"
        | Samantha_mistral_7B -> "samantha-mistral:7b"
        | Paraphrase_multilingual_278M -> "paraphrase-multilingual:278m"
        | Nemotron_mini_4B -> "nemotron-mini:4b"
        | Tulu3_8B -> "tulu3:8b"
        | Granite_embedding_30M -> "granite-embedding:30m"
        | Starling_lm_7B -> "starling-lm:7b"
        | Phind_codellama_34B -> "phind-codellama:34b"
        | Internlm2_7B -> "internlm2:7b"
        | Solar_10_7B -> "solar:10.7b"
        | Xwinlm_7B -> "xwinlm:7b"
        | Athene_v2_72B -> "athene-v2:72b"
        | Llama3_groq_tool_use_8B -> "llama3-groq-tool-use:8b"
        | Nemotron_70B -> "nemotron:70b"
        | Yarn_llama2_7B -> "yarn-llama2:7b"
        | Meditron_7B -> "meditron:7b"
        | Granite3_moe_1B -> "granite3-moe:1b"
        | Wizardlm_uncensored_13B -> "wizardlm-uncensored:13b"
        | Llama_guard3_8B -> "llama-guard3:8b"
        | Aya_expanse_8B -> "aya-expanse:8b"
        | Smallthinker_3B -> "smallthinker:3b"
        | Orca2_7B -> "orca2:7b"
        | Wizardlm_70B_llama2_q8_0 -> "wizardlm:70b-llama2-q8_0"
        | Medllama2_7B -> "medllama2:7b"
        | Nous_hermes2_mixtral_8x7B -> "nous-hermes2-mixtral:8x7b"
        | Stable_beluga_7B -> "stable-beluga:7b"
        | Deepseek_v2_5_236B -> "deepseek-v2.5:236b"
        | Reader_lm_1_5B -> "reader-lm:1.5b"
        | Command_r7b_7B -> "command-r7b:7b"
        | Phi4_mini_reasoning_3_8B -> "phi4-mini-reasoning:3.8b"
        | Llama_pro_instruct -> "llama-pro:instruct"
        | Shieldgemma_9B -> "shieldgemma:9b"
        | Yarn_mistral_7B -> "yarn-mistral:7b"
        | Command_a_111B -> "command-a:111b"
        | Mathstral_7B -> "mathstral:7b"
        | Nexusraven_13B -> "nexusraven:13b"
        | Everythinglm_13B -> "everythinglm:13b"
        | Codeup_13B -> "codeup:13b"
        | Marco_o1_7B -> "marco-o1:7b"
        | Stablelm_zephyr_3B -> "stablelm-zephyr:3b"
        | Solar_pro_22B -> "solar-pro:22b"
        | Qwen3_embedding_8B -> "qwen3-embedding:8b"
        | Duckdb_nsql_7B -> "duckdb-nsql:7b"
        | Falcon2_11B -> "falcon2:11b"
        | Magicoder_7B -> "magicoder:7b"
        | Mistrallite_7B -> "mistrallite:7b"
        | Codebooga_34B -> "codebooga:34b"
        | Bespoke_minicheck_7B -> "bespoke-minicheck:7b"
        | Nuextract_3_8B -> "nuextract:3.8b"
        | Wizard_vicuna_13B -> "wizard-vicuna:13b"
        | Granite3_guardian_2B -> "granite3-guardian:2b"
        | Megadolphin_120B -> "megadolphin:120b"
        | Notux_8x7B -> "notux:8x7b"
        | Open_orca_platypus2_13B -> "open-orca-platypus2:13b"
        | Notus_7B -> "notus:7b"
        | Sailor2_8B -> "sailor2:8b"
        | Firefunction_v2_70B -> "firefunction-v2:70b"
        | Goliath_120B_fp16 -> "goliath:120b-fp16"
        | Granite4_micro -> "granite4:micro"
        | Alfred_40B -> "alfred:40b"
        | Command_r7b_arabic_7B -> "command-r7b-arabic:7b"
        | Kimi_k2_1T_cloud -> "kimi-k2:1t-cloud"


    static member initClient (m: Model) =
        new OllamaApiClient(new Uri("http://localhost:11434/"), Model.getModelName m)
        :> IChatClient

module Prompt =
    let getResponse (client: IChatClient) (prompt: string) =
        task{
            if String.IsNullOrWhiteSpace(prompt) then
                return! Task.FromException<ChatResponse>(ArgumentException("Prompt must not be empty"))
            else
                let messages = [ChatMessage(ChatRole.User, prompt)]
                let! response = client.GetResponseAsync(messages)
                return response
        }
        |> Async.AwaitTask
        |> Async.RunSynchronously

    let getResponseText (client: IChatClient) (prompt: string) =
        getResponse client prompt
        |> _.ToString()

    let chatHistory = List<ChatMessage>()

    let getResponseWithChatHistoryText (client: IChatClient) (chatHistory: List<ChatMessage>) (prompt: string) =
        task{
            if String.IsNullOrWhiteSpace(prompt) then
                return "Please specify answer!"
            else
                chatHistory.Add(ChatMessage(ChatRole.User, prompt))
                let! response = client.GetResponseAsync(chatHistory)
                chatHistory.Add(ChatMessage(ChatRole.Assistant, response.Text))
                return response.Text
        }
        |> Async.AwaitTask
        |> Async.RunSynchronously
