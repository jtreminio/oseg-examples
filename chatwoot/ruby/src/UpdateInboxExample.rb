require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

channel = ChatwootClient::UpdateInboxRequestChannel.new
channel.website_url = nil
channel.welcome_title = nil
channel.welcome_tagline = nil
channel.agent_away_message = nil
channel.widget_color = nil

update_inbox_request = ChatwootClient::UpdateInboxRequest.new
update_inbox_request.enable_auto_assignment = nil
update_inbox_request.name = nil
update_inbox_request.avatar = nil
update_inbox_request.channel = channel

begin
    response = ChatwootClient::InboxesApi.new.update_inbox(
        nil, # account_id
        nil, # id
        update_inbox_request, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling InboxesApi#update_inbox: #{e}"
end
