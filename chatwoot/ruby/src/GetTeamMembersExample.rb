require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
end

begin
    response = ChatwootClient::TeamsApi.new.get_team_members(
        0, # account_id
        0, # team_id
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling TeamsApi#get_team_members: #{e}"
end
