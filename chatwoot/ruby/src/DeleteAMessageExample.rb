require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
    # config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

begin
    ChatwootClient::MessagesApi.new.delete_a_message(
        0, # account_id
        0, # conversation_id
        0, # message_id
    )
rescue ChatwootClient::ApiError => e
    puts "Exception when calling MessagesApi#delete_a_message: #{e}"
end
