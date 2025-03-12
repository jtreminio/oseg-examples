require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

user_create_update_payload = ChatwootClient::UserCreateUpdatePayload.new
user_create_update_payload.name = nil
user_create_update_payload.email = nil
user_create_update_payload.password = nil

begin
    response = ChatwootClient::UsersApi.new.create_a_user(
        user_create_update_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling UsersApi#create_a_user: #{e}"
end
