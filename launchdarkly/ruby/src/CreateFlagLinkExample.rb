require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

flag_link_post = LaunchDarklyClient::FlagLinkPost.new
flag_link_post.key = "flag-link-key-123abc"
flag_link_post.deep_link = "https://example.com/archives/123123123"
flag_link_post.title = "Example link title"
flag_link_post.description = "Example link description"

begin
    response = LaunchDarklyClient::FlagLinksBetaApi.new.create_flag_link(
        "projectKey_string", # project_key
        "featureFlagKey_string", # feature_flag_key
        flag_link_post,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FlagLinksBetaApi#create_flag_link: #{e}"
end
