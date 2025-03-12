require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

integrations_hook_update_payload = ChatwootClient::IntegrationsHookUpdatePayload.new

begin
    response = ChatwootClient::IntegrationsApi.new.update_an_integrations_hook(
        nil, # account_id
        nil, # hook_id
        integrations_hook_update_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling IntegrationsApi#update_an_integrations_hook: #{e}"
end
