require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::ExperimentsApi.new.get_experiment(
        "projectKey_string", # project_key
        "environmentKey_string", # environment_key
        "experimentKey_string", # experiment_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ExperimentsApi#get_experiment: #{e}"
end
