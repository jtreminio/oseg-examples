require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
end

begin
    ChatwootClient::AutomationRuleApi.new.delete_automation_rule_from_account(
        0, # account_id
        0, # id
    )
rescue ChatwootClient::ApiError => e
    puts "Exception when calling AutomationRuleApi#delete_automation_rule_from_account: #{e}"
end
