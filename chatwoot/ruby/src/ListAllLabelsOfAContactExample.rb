require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
    # config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

begin
    response = ChatwootClient::ContactLabelsApi.new.list_all_labels_of_a_contact(
        0, # account_id
        "contact_identifier_string", # contact_identifier
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ContactLabelsApi#list_all_labels_of_a_contact: #{e}"
end
