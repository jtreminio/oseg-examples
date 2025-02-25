require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::ReleasesBetaApi.new.delete_release_by_flag_key(
        nil, # project_key
        nil, # flag_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ReleasesBeta#delete_release_by_flag_key: #{e}"
end
