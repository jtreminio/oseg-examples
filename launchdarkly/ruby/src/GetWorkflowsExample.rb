require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::WorkflowsApi.new.get_workflows(
        nil, # project_key
        nil, # feature_flag_key
        nil, # environment_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling WorkflowsApi#get_workflows: #{e}"
end
