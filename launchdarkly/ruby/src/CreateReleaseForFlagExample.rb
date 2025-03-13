require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

create_release_input = LaunchDarklyClient::CreateReleaseInput.new
create_release_input.release_pipeline_key = nil
create_release_input.release_variation_id = nil

begin
    response = LaunchDarklyClient::ReleasesBetaApi.new.create_release_for_flag(
        nil, # project_key
        nil, # flag_key
        create_release_input,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ReleasesBetaApi#create_release_for_flag: #{e}"
end
