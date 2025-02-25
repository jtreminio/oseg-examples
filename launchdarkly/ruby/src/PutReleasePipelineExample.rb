require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

phases_1_audiences_1_configuration_release_guardian_configuration = LaunchDarklyClient::ReleaseGuardianConfiguration.new
phases_1_audiences_1_configuration_release_guardian_configuration.monitoring_window_milliseconds = 60000
phases_1_audiences_1_configuration_release_guardian_configuration.rollout_weight = 50
phases_1_audiences_1_configuration_release_guardian_configuration.rollback_on_regression = true
phases_1_audiences_1_configuration_release_guardian_configuration.randomization_unit = "user"

phases_1_audiences_1_configuration = LaunchDarklyClient::AudienceConfiguration.new
phases_1_audiences_1_configuration.release_strategy = nil
phases_1_audiences_1_configuration.require_approval = true
phases_1_audiences_1_configuration.notify_member_ids = [
    "1234a56b7c89d012345e678f",
]
phases_1_audiences_1_configuration.notify_team_keys = [
    "example-reviewer-team",
]
phases_1_audiences_1_configuration.release_guardian_configuration = phases_1_audiences_1_configuration_release_guardian_configuration

phases_1_audiences_1 = LaunchDarklyClient::AudiencePost.new
phases_1_audiences_1.environment_key = nil
phases_1_audiences_1.name = nil
phases_1_audiences_1.segment_keys = [
]
phases_1_audiences_1.configuration = phases_1_audiences_1_configuration

phases_1_audiences = [
    phases_1_audiences_1,
]

phases_1 = LaunchDarklyClient::CreatePhaseInput.new
phases_1.name = "Phase 1 - Testing"
phases_1.audiences = phases_1_audiences

phases = [
    phases_1,
]

update_release_pipeline_input = LaunchDarklyClient::UpdateReleasePipelineInput.new
update_release_pipeline_input.name = "Standard Pipeline"
update_release_pipeline_input.description = "Standard pipeline to roll out to production"
update_release_pipeline_input.tags = [
    "example-tag",
]
update_release_pipeline_input.phases = phases

begin
    response = LaunchDarklyClient::ReleasePipelinesBetaApi.new.put_release_pipeline(
        nil, # project_key
        nil, # pipeline_key
        update_release_pipeline_input,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ReleasePipelinesBeta#put_release_pipeline: #{e}"
end
