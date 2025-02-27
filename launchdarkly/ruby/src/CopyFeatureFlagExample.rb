require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

source = LaunchDarklyClient::FlagCopyConfigEnvironment.new
source.key = "source-env-key-123abc"
source.current_version = 1

target = LaunchDarklyClient::FlagCopyConfigEnvironment.new
target.key = "target-env-key-123abc"
target.current_version = 1

flag_copy_config_post = LaunchDarklyClient::FlagCopyConfigPost.new
flag_copy_config_post.comment = "optional comment"
flag_copy_config_post.source = source
flag_copy_config_post.target = target

begin
    response = LaunchDarklyClient::FeatureFlagsApi.new.copy_feature_flag(
        nil, # project_key
        nil, # feature_flag_key
        flag_copy_config_post,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FeatureFlagsApi#copy_feature_flag: #{e}"
end
