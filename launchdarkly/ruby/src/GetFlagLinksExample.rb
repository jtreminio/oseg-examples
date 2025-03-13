require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::FlagLinksBetaApi.new.get_flag_links(
        "projectKey_string", # project_key
        "featureFlagKey_string", # feature_flag_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FlagLinksBetaApi#get_flag_links: #{e}"
end
