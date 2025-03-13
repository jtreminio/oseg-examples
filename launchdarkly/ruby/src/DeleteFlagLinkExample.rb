require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::FlagLinksBetaApi.new.delete_flag_link(
        "projectKey_string", # project_key
        "featureFlagKey_string", # feature_flag_key
        "id_string", # id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FlagLinksBetaApi#delete_flag_link: #{e}"
end
