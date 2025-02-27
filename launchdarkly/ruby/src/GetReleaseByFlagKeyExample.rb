require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::ReleasesBetaApi.new.get_release_by_flag_key(
        nil, # project_key
        nil, # flag_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ReleasesBetaApi#get_release_by_flag_key: #{e}"
end
