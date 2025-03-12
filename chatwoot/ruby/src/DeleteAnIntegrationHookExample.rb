require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

begin
    ChatwootClient::IntegrationsApi.new.delete_an_integration_hook(
        nil, # account_id
        nil, # hook_id
    )
rescue ChatwootClient::ApiError => e
    puts "Exception when calling IntegrationsApi#delete_an_integration_hook: #{e}"
end
