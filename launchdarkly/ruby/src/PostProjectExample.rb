require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

project_post = LaunchDarklyClient::ProjectPost.new
project_post.name = "My Project"
project_post.key = "project-key-123abc"

begin
    response = LaunchDarklyClient::ProjectsApi.new.post_project(
        project_post,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ProjectsApi#post_project: #{e}"
end
