require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

begin
    ChatwootClient::UsersApi.new.delete_a_user(
        nil, # id
    )
rescue ChatwootClient::ApiError => e
    puts "Exception when calling UsersApi#delete_a_user: #{e}"
end
