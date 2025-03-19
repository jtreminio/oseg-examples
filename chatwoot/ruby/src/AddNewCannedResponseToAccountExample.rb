require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
end

canned_response_create_update_payload = ChatwootClient::CannedResponseCreateUpdatePayload.new

begin
    response = ChatwootClient::CannedResponsesApi.new.add_new_canned_response_to_account(
        0, # account_id
        canned_response_create_update_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling CannedResponsesApi#add_new_canned_response_to_account: #{e}"
end
