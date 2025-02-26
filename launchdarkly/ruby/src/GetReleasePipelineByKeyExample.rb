require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::ReleasePipelinesBetaApi.new.get_release_pipeline_by_key(
        nil, # project_key
        nil, # pipeline_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ReleasePipelinesBetaApi#get_release_pipeline_by_key: #{e}"
end
