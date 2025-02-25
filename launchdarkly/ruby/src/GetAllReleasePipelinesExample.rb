require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::ReleasePipelinesBetaApi.new.get_all_release_pipelines(
        nil, # project_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ReleasePipelinesBeta#get_all_release_pipelines: #{e}"
end
