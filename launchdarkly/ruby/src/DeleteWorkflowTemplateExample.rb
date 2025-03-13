require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::WorkflowTemplatesApi.new.delete_workflow_template(
        nil, # template_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling WorkflowTemplatesApi#delete_workflow_template: #{e}"
end
