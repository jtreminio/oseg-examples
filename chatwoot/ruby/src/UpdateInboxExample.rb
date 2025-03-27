require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
    # config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

update_inbox_request = ChatwootClient::UpdateInboxRequest.new
update_inbox_request.enable_auto_assignment = false

begin
    response = ChatwootClient::InboxesApi.new.update_inbox(
        0, # account_id
        (0).to_f, # id
        update_inbox_request, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling InboxesApi#update_inbox: #{e}"
end
