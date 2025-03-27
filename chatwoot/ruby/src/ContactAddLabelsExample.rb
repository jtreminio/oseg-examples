require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
    # config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

contact_add_labels_request = ChatwootClient::ContactAddLabelsRequest.new
contact_add_labels_request.labels = [
]

begin
    response = ChatwootClient::ContactLabelsApi.new.contact_add_labels(
        0, # account_id
        "contact_identifier_string", # contact_identifier
        contact_add_labels_request, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ContactLabelsApi#contact_add_labels: #{e}"
end
