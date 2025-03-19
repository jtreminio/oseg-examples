require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
    # config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

update_agent_bot_request = ChatwootClient::UpdateAgentBotRequest.new
update_agent_bot_request.agent_bot = 0

begin
    ChatwootClient::InboxesApi.new.update_agent_bot(
        0, # account_id
        0, # id
        update_agent_bot_request, # data
    )
rescue ChatwootClient::ApiError => e
    puts "Exception when calling InboxesApi#update_agent_bot: #{e}"
end
