require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

extinction_1 = LaunchDarklyClient::Extinction.new
extinction_1.revision = "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3"
extinction_1.message = "Remove flag for launched feature"
extinction_1.time = 1706701522000
extinction_1.flag_key = "enable-feature"
extinction_1.proj_key = "default"

extinction = [
    extinction_1,
]

begin
    LaunchDarklyClient::CodeReferencesApi.new.post_extinction(
        "repo_string", # repo
        "branch_string", # branch
        extinction,
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling CodeReferencesApi#post_extinction: #{e}"
end
