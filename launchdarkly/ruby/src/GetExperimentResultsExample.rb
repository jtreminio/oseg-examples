require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::ExperimentsApi.new.get_experiment_results(
        nil, # project_key
        nil, # environment_key
        nil, # experiment_key
        nil, # metric_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling Experiments#get_experiment_results: #{e}"
end
