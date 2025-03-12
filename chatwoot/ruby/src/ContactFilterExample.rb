require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
end

contact_filter_request = ChatwootClient::ContactFilterRequest.new
contact_filter_request.payload = JSON.parse(<<-EOD
    [
        {
            "attribute_key": "name",
            "filter_operator": "equal_to",
            "query_operator": "AND",
            "values": [
                "en"
            ]
        },
        {
            "attribute_key": "country_code",
            "filter_operator": "equal_to",
            "query_operator": null,
            "values": [
                "us"
            ]
        }
    ]
    EOD
)

begin
    response = ChatwootClient::ContactsApi.new.contact_filter(
        nil, # account_id
        contact_filter_request, # body
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ContactsApi#contact_filter: #{e}"
end
