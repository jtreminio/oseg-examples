require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
    # config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

begin
    response = ChatwootClient::ConversationsAPIApi.new.get_single_conversation(
        "inbox_identifier_string", # inbox_identifier
        "contact_identifier_string", # contact_identifier
        0, # conversation_id
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ConversationsAPIApi#get_single_conversation: #{e}"
end
