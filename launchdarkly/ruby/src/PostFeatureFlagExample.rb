require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

client_side_availability = LaunchDarklyClient::ClientSideAvailabilityPost.new
client_side_availability.using_environment_id = true
client_side_availability.using_mobile_key = true

feature_flag_body = LaunchDarklyClient::FeatureFlagBody.new
feature_flag_body.name = "My Flag"
feature_flag_body.key = "flag-key-123abc"
feature_flag_body.client_side_availability = client_side_availability

begin
    response = LaunchDarklyClient::FeatureFlagsApi.new.post_feature_flag(
        nil, # project_key
        feature_flag_body,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FeatureFlagsApi#post_feature_flag: #{e}"
end
