require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

begin
    ChatwootClient::AccountsApi.new.delete_an_account(
        0, # account_id
    )
rescue ChatwootClient::ApiError => e
    puts "Exception when calling AccountsApi#delete_an_account: #{e}"
end
