require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

create_release_input = LaunchDarklyClient::CreateReleaseInput.new
create_release_input.release_pipeline_key = "releasePipelineKey_string"

begin
    response = LaunchDarklyClient::ReleasesBetaApi.new.create_release_for_flag(
        "projectKey_string", # project_key
        "flagKey_string", # flag_key
        create_release_input,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ReleasesBetaApi#create_release_for_flag: #{e}"
end
