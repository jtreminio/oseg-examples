require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
end

begin
    ChatwootClient::AgentsApi.new.delete_agent_from_account(
        nil, # account_id
        nil, # id
    )
rescue ChatwootClient::ApiError => e
    puts "Exception when calling AgentsApi#delete_agent_from_account: #{e}"
end
