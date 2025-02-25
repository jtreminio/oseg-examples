require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::FlagImportConfigurationsBetaApi.new.trigger_flag_import_job(
        nil, # project_key
        nil, # integration_key
        nil, # integration_id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FlagImportConfigurationsBeta#trigger_flag_import_job: #{e}"
end
