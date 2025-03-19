require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
end

conversation_filter_request = ChatwootClient::ConversationFilterRequest.new
conversation_filter_request.payload = JSON.parse(<<-EOD
    [
        {
            "attribute_key": "browser_language",
            "filter_operator": "not_eq",
            "query_operator": "AND",
            "values": [
                "en"
            ]
        },
        {
            "attribute_key": "status",
            "filter_operator": "eq",
            "query_operator": null,
            "values": [
                "pending"
            ]
        }
    ]
    EOD
)

begin
    response = ChatwootClient::ConversationsApi.new.conversation_filter(
        0, # account_id
        conversation_filter_request, # body
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ConversationsApi#conversation_filter: #{e}"
end
