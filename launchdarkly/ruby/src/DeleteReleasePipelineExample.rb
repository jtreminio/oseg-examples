require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::ReleasePipelinesBetaApi.new.delete_release_pipeline(
        nil, # project_key
        nil, # pipeline_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ReleasePipelinesBetaApi#delete_release_pipeline: #{e}"
end
