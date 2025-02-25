require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::ReleasePipelinesBetaApi.new.get_all_release_progressions_for_release_pipeline(
        nil, # project_key
        nil, # pipeline_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ReleasePipelinesBeta#get_all_release_progressions_for_release_pipeline: #{e}"
end
