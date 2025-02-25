require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::WorkflowTemplatesApi.new.get_workflow_templates

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling WorkflowTemplates#get_workflow_templates: #{e}"
end
