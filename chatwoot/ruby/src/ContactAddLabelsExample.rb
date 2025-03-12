require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

contact_add_labels_request = ChatwootClient::ContactAddLabelsRequest.new
contact_add_labels_request.labels = [
]

begin
    response = ChatwootClient::ContactLabelsApi.new.contact_add_labels(
        nil, # account_id
        nil, # contact_identifier
        contact_add_labels_request, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ContactLabelsApi#contact_add_labels: #{e}"
end
