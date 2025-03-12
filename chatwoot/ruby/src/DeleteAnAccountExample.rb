require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

begin
    ChatwootClient::AccountsApi.new.delete_an_account(
        nil, # account_id
    )
rescue ChatwootClient::ApiError => e
    puts "Exception when calling AccountsApi#delete_an_account: #{e}"
end
