require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
end

automation_rule_create_update_payload = ChatwootClient::AutomationRuleCreateUpdatePayload.new
automation_rule_create_update_payload.name = "Add label on message create event"
automation_rule_create_update_payload.description = "Add label support and sales on message create event if incoming message content contains text help"
automation_rule_create_update_payload.event_name = "message_created"
automation_rule_create_update_payload.actions = JSON.parse(<<-EOD
    [
        {
            "action_name": "add_label",
            "action_params": [
                "support"
            ]
        }
    ]
    EOD
)
automation_rule_create_update_payload.conditions = JSON.parse(<<-EOD
    [
        {
            "attribute_key": "content",
            "filter_operator": "contains",
            "query_operator": "nil",
            "values": [
                "help"
            ]
        }
    ]
    EOD
)

begin
    response = ChatwootClient::AutomationRuleApi.new.add_new_automation_rule_to_account(
        0, # account_id
        automation_rule_create_update_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling AutomationRuleApi#add_new_automation_rule_to_account: #{e}"
end
