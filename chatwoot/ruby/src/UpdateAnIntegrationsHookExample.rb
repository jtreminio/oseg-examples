require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
    # config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

integrations_hook_update_payload = ChatwootClient::IntegrationsHookUpdatePayload.new

begin
    response = ChatwootClient::IntegrationsApi.new.update_an_integrations_hook(
        0, # account_id
        0, # hook_id
        integrations_hook_update_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling IntegrationsApi#update_an_integrations_hook: #{e}"
end
