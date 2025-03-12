require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
end

begin
    response = ChatwootClient::AutomationRuleApi.new.get_account_automation_rule(
        nil, # account_id
        {
            page: 1,
        },
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling AutomationRuleApi#get_account_automation_rule: #{e}"
end
