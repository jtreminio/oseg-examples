require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::FlagImportConfigurationsBetaApi.new.get_flag_import_configuration(
        "projectKey_string", # project_key
        "integrationKey_string", # integration_key
        "integrationId_string", # integration_id
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FlagImportConfigurationsBetaApi#get_flag_import_configuration: #{e}"
end
