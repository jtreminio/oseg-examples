require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

value_put = LaunchDarklyClient::ValuePut.new
value_put.comment = "make sure this context experiences a specific variation"

begin
    LaunchDarklyClient::ContextSettingsApi.new.put_context_flag_setting(
        nil, # project_key
        nil, # environment_key
        nil, # context_kind
        nil, # context_key
        nil, # feature_flag_key
        value_put,
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ContextSettings#put_context_flag_setting: #{e}"
end
