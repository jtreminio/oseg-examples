require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::HoldoutsBetaApi.new.get_holdout_by_id(
        nil, # project_key
        nil, # environment_key
        nil, # holdout_id
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling HoldoutsBetaApi#get_holdout_by_id: #{e}"
end
