require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

repository_post = LaunchDarklyClient::RepositoryPost.new
repository_post.name = "LaunchDarkly-Docs"
repository_post.source_link = "https://github.com/launchdarkly/LaunchDarkly-Docs"
repository_post.commit_url_template = "https://github.com/launchdarkly/LaunchDarkly-Docs/commit/${sha}"
repository_post.hunk_url_template = "https://github.com/launchdarkly/LaunchDarkly-Docs/blob/${sha}/${filePath}#L${lineNumber}"
repository_post.type = "github"
repository_post.default_branch = "main"

begin
    response = LaunchDarklyClient::CodeReferencesApi.new.post_repository(
        repository_post,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling CodeReferencesApi#post_repository: #{e}"
end
