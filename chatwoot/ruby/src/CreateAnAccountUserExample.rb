require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

create_an_account_user_request = ChatwootClient::CreateAnAccountUserRequest.new
create_an_account_user_request.role = "role_string"
create_an_account_user_request.user_id = 0

begin
    response = ChatwootClient::AccountUsersApi.new.create_an_account_user(
        0, # account_id
        create_an_account_user_request, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling AccountUsersApi#create_an_account_user: #{e}"
end
