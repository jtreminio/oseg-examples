require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::WorkflowsApi.new.get_custom_workflow(
        nil, # project_key
        nil, # feature_flag_key
        nil, # environment_key
        nil, # workflow_id
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling Workflows#get_custom_workflow: #{e}"
end
