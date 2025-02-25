require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::FlagLinksBetaApi.new.delete_flag_link(
        nil, # project_key
        nil, # feature_flag_key
        nil, # id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FlagLinksBeta#delete_flag_link: #{e}"
end
