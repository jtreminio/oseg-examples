require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
end

automation_rule_create_update_payload = ChatwootClient::AutomationRuleCreateUpdatePayload.new
automation_rule_create_update_payload.name = "Add label on message create event"
automation_rule_create_update_payload.description = "Add label support and sales on message create event if incoming message content contains text help"
automation_rule_create_update_payload.event_name = "message_created"
automation_rule_create_update_payload.active = nil

begin
    response = ChatwootClient::AutomationRuleApi.new.update_automation_rule_in_account(
        nil, # account_id
        nil, # id
        automation_rule_create_update_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling AutomationRuleApi#update_automation_rule_in_account: #{e}"
end
