require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::ExperimentsApi.new.get_experiment_results_for_metric_group(
        nil, # project_key
        nil, # environment_key
        nil, # experiment_key
        nil, # metric_group_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ExperimentsApi#get_experiment_results_for_metric_group: #{e}"
end
