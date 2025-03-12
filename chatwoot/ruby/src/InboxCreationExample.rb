require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

channel = ChatwootClient::InboxCreationRequestChannel.new
channel.type = nil
channel.website_url = nil
channel.welcome_title = nil
channel.welcome_tagline = nil
channel.agent_away_message = nil
channel.widget_color = nil

inbox_creation_request = ChatwootClient::InboxCreationRequest.new
inbox_creation_request.name = nil
inbox_creation_request.avatar = nil
inbox_creation_request.channel = channel

begin
    response = ChatwootClient::InboxesApi.new.inbox_creation(
        nil, # account_id
        inbox_creation_request, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling InboxesApi#inbox_creation: #{e}"
end
