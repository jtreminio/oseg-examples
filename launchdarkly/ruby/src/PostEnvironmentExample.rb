require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

environment_post = LaunchDarklyClient::EnvironmentPost.new
environment_post.name = "My Environment"
environment_post.key = "environment-key-123abc"
environment_post.color = "DADBEE"

begin
    response = LaunchDarklyClient::EnvironmentsApi.new.post_environment(
        nil, # project_key
        environment_post,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling EnvironmentsApi#post_environment: #{e}"
end
