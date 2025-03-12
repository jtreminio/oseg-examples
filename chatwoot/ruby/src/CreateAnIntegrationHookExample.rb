require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

integrations_hook_create_payload = ChatwootClient::IntegrationsHookCreatePayload.new
integrations_hook_create_payload.app_id = nil
integrations_hook_create_payload.inbox_id = nil

begin
    response = ChatwootClient::IntegrationsApi.new.create_an_integration_hook(
        nil, # account_id
        integrations_hook_create_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling IntegrationsApi#create_an_integration_hook: #{e}"
end
