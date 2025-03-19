require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
end

begin
    response = ChatwootClient::HelpCenterApi.new.get_portal(
        0, # account_id
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling HelpCenterApi#get_portal: #{e}"
end
