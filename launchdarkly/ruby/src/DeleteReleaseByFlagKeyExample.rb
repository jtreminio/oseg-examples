require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::ReleasesBetaApi.new.delete_release_by_flag_key(
        "projectKey_string", # project_key
        "flagKey_string", # flag_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ReleasesBetaApi#delete_release_by_flag_key: #{e}"
end
