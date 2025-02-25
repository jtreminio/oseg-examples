require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::HoldoutsBetaApi.new.get_holdout(
        nil, # project_key
        nil, # environment_key
        nil, # holdout_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling HoldoutsBeta#get_holdout: #{e}"
end
