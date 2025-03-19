require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
end

canned_response_create_update_payload = ChatwootClient::CannedResponseCreateUpdatePayload.new

begin
    response = ChatwootClient::CannedResponseApi.new.update_canned_response_in_account(
        0, # account_id
        0, # id
        canned_response_create_update_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling CannedResponseApi#update_canned_response_in_account: #{e}"
end
