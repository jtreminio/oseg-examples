require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
    # config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

begin
    response = ChatwootClient::ConversationsApi.new.get_details_of_a_conversation(
        0, # account_id
        0, # conversation_id
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ConversationsApi#get_details_of_a_conversation: #{e}"
end
