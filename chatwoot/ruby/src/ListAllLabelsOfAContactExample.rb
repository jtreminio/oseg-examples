require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

begin
    response = ChatwootClient::ContactLabelsApi.new.list_all_labels_of_a_contact(
        nil, # account_id
        nil, # contact_identifier
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ContactLabelsApi#list_all_labels_of_a_contact: #{e}"
end
