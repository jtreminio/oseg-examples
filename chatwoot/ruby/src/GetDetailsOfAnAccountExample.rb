require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

begin
    response = ChatwootClient::AccountsApi.new.get_details_of_an_account(
        nil, # account_id
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling AccountsApi#get_details_of_an_account: #{e}"
end
