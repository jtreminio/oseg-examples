require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

begin
    response = ChatwootClient::UsersApi.new.get_details_of_a_user(
        nil, # id
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling UsersApi#get_details_of_a_user: #{e}"
end
