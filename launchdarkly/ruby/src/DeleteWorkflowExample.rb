require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::WorkflowsApi.new.delete_workflow(
        nil, # project_key
        nil, # feature_flag_key
        nil, # environment_key
        nil, # workflow_id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling WorkflowsApi#delete_workflow: #{e}"
end
