require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

randomization_units_1 = LaunchDarklyClient::RandomizationUnitInput.new
randomization_units_1.randomization_unit = "user"
randomization_units_1.standard_randomization_unit = "organization"

randomization_units = [
    randomization_units_1,
]

randomization_settings_put = LaunchDarklyClient::RandomizationSettingsPut.new
randomization_settings_put.randomization_units = randomization_units

begin
    response = LaunchDarklyClient::ExperimentsApi.new.put_experimentation_settings(
        "the-project-key", # project_key
        randomization_settings_put,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ExperimentsApi#put_experimentation_settings: #{e}"
end
