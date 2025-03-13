require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::ReleasePipelinesBetaApi.new.delete_release_pipeline(
        "projectKey_string", # project_key
        "pipelineKey_string", # pipeline_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ReleasePipelinesBetaApi#delete_release_pipeline: #{e}"
end
