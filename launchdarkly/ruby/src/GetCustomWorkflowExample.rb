require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::WorkflowsApi.new.get_custom_workflow(
        "projectKey_string", # project_key
        "featureFlagKey_string", # feature_flag_key
        "environmentKey_string", # environment_key
        "workflowId_string", # workflow_id
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling WorkflowsApi#get_custom_workflow: #{e}"
end
