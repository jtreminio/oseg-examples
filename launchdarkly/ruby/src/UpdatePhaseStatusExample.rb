require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

audiences_1_release_guardian_configuration = LaunchDarklyClient::ReleaseGuardianConfigurationInput.new
audiences_1_release_guardian_configuration.monitoring_window_milliseconds = 60000
audiences_1_release_guardian_configuration.rollout_weight = 50
audiences_1_release_guardian_configuration.rollback_on_regression = true
audiences_1_release_guardian_configuration.randomization_unit = "user"

audiences_1 = LaunchDarklyClient::ReleaserAudienceConfigInput.new
audiences_1.audience_id = nil
audiences_1.notify_member_ids = [
    "1234a56b7c89d012345e678f",
]
audiences_1.notify_team_keys = [
    "example-reviewer-team",
]
audiences_1.release_guardian_configuration = audiences_1_release_guardian_configuration

audiences = [
    audiences_1,
]

update_phase_status_input = LaunchDarklyClient::UpdatePhaseStatusInput.new
update_phase_status_input.status = nil
update_phase_status_input.audiences = audiences

begin
    response = LaunchDarklyClient::ReleasesBetaApi.new.update_phase_status(
        nil, # project_key
        nil, # flag_key
        nil, # phase_id
        update_phase_status_input,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ReleasesBeta#update_phase_status: #{e}"
end
