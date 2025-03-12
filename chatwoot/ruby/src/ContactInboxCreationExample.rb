require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

contact_inbox_creation_request = ChatwootClient::ContactInboxCreationRequest.new
contact_inbox_creation_request.inbox_id = nil
contact_inbox_creation_request.source_id = nil

begin
    response = ChatwootClient::ContactApi.new.contact_inbox_creation(
        nil, # account_id
        nil, # id
        contact_inbox_creation_request, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ContactApi#contact_inbox_creation: #{e}"
end
