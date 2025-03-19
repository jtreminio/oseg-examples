require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
    # config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

inbox_creation_request = ChatwootClient::InboxCreationRequest.new

begin
    response = ChatwootClient::InboxesApi.new.inbox_creation(
        0, # account_id
        inbox_creation_request, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling InboxesApi#inbox_creation: #{e}"
end
