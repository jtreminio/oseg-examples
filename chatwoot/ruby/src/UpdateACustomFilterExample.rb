require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

custom_filter_create_update_payload = ChatwootClient::CustomFilterCreateUpdatePayload.new
custom_filter_create_update_payload.name = nil
custom_filter_create_update_payload.type = nil

begin
    response = ChatwootClient::CustomFiltersApi.new.update_a_custom_filter(
        nil, # account_id
        nil, # custom_filter_id
        custom_filter_create_update_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling CustomFiltersApi#update_a_custom_filter: #{e}"
end
