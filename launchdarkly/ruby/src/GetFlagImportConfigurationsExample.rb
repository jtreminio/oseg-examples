require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::FlagImportConfigurationsBetaApi.new.get_flag_import_configurations

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FlagImportConfigurationsBeta#get_flag_import_configurations: #{e}"
end
