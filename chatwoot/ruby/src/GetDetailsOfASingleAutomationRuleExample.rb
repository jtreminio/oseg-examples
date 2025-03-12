require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

begin
    response = ChatwootClient::AutomationRuleApi.new.get_details_of_a_single_automation_rule(
        nil, # account_id
        nil, # id
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling AutomationRuleApi#get_details_of_a_single_automation_rule: #{e}"
end
