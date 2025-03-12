require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
end

canned_response_create_update_payload = ChatwootClient::CannedResponseCreateUpdatePayload.new
canned_response_create_update_payload.content = nil
canned_response_create_update_payload.short_code = nil

begin
    response = ChatwootClient::CannedResponseApi.new.update_canned_response_in_account(
        nil, # account_id
        nil, # id
        canned_response_create_update_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling CannedResponseApi#update_canned_response_in_account: #{e}"
end
