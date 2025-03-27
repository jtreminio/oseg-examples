require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

delete_an_account_user_request = ChatwootClient::DeleteAnAccountUserRequest.new
delete_an_account_user_request.user_id = 0

begin
    ChatwootClient::AccountUsersApi.new.delete_an_account_user(
        0, # account_id
        delete_an_account_user_request, # data
    )
rescue ChatwootClient::ApiError => e
    puts "Exception when calling AccountUsersApi#delete_an_account_user: #{e}"
end
