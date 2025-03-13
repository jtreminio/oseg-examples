require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::ReleasePipelinesBetaApi.new.get_all_release_progressions_for_release_pipeline(
        "projectKey_string", # project_key
        "pipelineKey_string", # pipeline_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ReleasePipelinesBetaApi#get_all_release_progressions_for_release_pipeline: #{e}"
end
