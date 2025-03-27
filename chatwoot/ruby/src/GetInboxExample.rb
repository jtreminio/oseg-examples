require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
    # config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

begin
    response = ChatwootClient::InboxesApi.new.get_inbox(
        0, # account_id
        (0).to_f, # id
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling InboxesApi#get_inbox: #{e}"
end
