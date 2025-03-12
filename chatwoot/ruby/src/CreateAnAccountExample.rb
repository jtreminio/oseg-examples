require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

account_create_update_payload = ChatwootClient::AccountCreateUpdatePayload.new
account_create_update_payload.name = nil

begin
    response = ChatwootClient::AccountsApi.new.create_an_account(
        account_create_update_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling AccountsApi#create_an_account: #{e}"
end
