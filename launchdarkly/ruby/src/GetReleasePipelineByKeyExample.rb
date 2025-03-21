require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::ReleasePipelinesBetaApi.new.get_release_pipeline_by_key(
        "projectKey_string", # project_key
        "pipelineKey_string", # pipeline_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ReleasePipelinesBetaApi#get_release_pipeline_by_key: #{e}"
end
