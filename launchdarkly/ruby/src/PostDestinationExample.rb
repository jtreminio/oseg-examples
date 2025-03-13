require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

destination_post = LaunchDarklyClient::DestinationPost.new
destination_post.kind = "google-pubsub"

begin
    response = LaunchDarklyClient::DataExportDestinationsApi.new.post_destination(
        nil, # project_key
        nil, # environment_key
        destination_post,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling DataExportDestinationsApi#post_destination: #{e}"
end
