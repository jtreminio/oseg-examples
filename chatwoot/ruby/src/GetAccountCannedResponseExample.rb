require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
end

begin
    response = ChatwootClient::CannedResponsesApi.new.get_account_canned_response(
        nil, # account_id
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling CannedResponsesApi#get_account_canned_response: #{e}"
end
