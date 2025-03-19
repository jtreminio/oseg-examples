require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
    # config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

contact_inbox_creation_request = ChatwootClient::ContactInboxCreationRequest.new
contact_inbox_creation_request.inbox_id = 0

begin
    response = ChatwootClient::ContactApi.new.contact_inbox_creation(
        0, # account_id
        0, # id
        contact_inbox_creation_request, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ContactApi#contact_inbox_creation: #{e}"
end
