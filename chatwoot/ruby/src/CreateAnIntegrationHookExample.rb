require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
    # config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

integrations_hook_create_payload = ChatwootClient::IntegrationsHookCreatePayload.new

begin
    response = ChatwootClient::IntegrationsApi.new.create_an_integration_hook(
        0, # account_id
        integrations_hook_create_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling IntegrationsApi#create_an_integration_hook: #{e}"
end
