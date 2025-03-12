require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

update_agent_bot_request = ChatwootClient::UpdateAgentBotRequest.new
update_agent_bot_request.agent_bot = nil

begin
    ChatwootClient::InboxesApi.new.update_agent_bot(
        nil, # account_id
        nil, # id
        update_agent_bot_request, # data
    )
rescue ChatwootClient::ApiError => e
    puts "Exception when calling InboxesApi#update_agent_bot: #{e}"
end
