require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::FlagImportConfigurationsBetaApi.new.trigger_flag_import_job(
        "projectKey_string", # project_key
        "integrationKey_string", # integration_key
        "integrationId_string", # integration_id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FlagImportConfigurationsBetaApi#trigger_flag_import_job: #{e}"
end
