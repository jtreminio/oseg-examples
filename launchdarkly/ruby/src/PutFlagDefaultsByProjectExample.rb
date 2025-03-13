require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

boolean_defaults = LaunchDarklyClient::BooleanFlagDefaults.new
boolean_defaults.true_display_name = "True"
boolean_defaults.false_display_name = "False"
boolean_defaults.true_description = "serve true"
boolean_defaults.false_description = "serve false"
boolean_defaults.on_variation = 0
boolean_defaults.off_variation = 1

default_client_side_availability = LaunchDarklyClient::DefaultClientSideAvailability.new
default_client_side_availability.using_mobile_key = true
default_client_side_availability.using_environment_id = true

upsert_flag_defaults_payload = LaunchDarklyClient::UpsertFlagDefaultsPayload.new
upsert_flag_defaults_payload.temporary = true
upsert_flag_defaults_payload.tags = [
    "tag-1",
    "tag-2",
]
upsert_flag_defaults_payload.boolean_defaults = boolean_defaults
upsert_flag_defaults_payload.default_client_side_availability = default_client_side_availability

begin
    response = LaunchDarklyClient::ProjectsApi.new.put_flag_defaults_by_project(
        nil, # project_key
        upsert_flag_defaults_payload,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ProjectsApi#put_flag_defaults_by_project: #{e}"
end
