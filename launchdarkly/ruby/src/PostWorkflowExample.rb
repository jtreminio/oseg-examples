require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

stages_1_action = LaunchDarklyClient::ActionInput.new

stages_1_conditions_1 = LaunchDarklyClient::ConditionInput.new
stages_1_conditions_1.schedule_kind = "relative"
stages_1_conditions_1.wait_duration = 2
stages_1_conditions_1.wait_duration_unit = "calendarDay"
stages_1_conditions_1.kind = "schedule"

stages_1_conditions = [
    stages_1_conditions_1,
]

stages_1 = LaunchDarklyClient::StageInput.new
stages_1.name = "10% rollout on day 1"
stages_1.action = stages_1_action
stages_1.conditions = stages_1_conditions

stages = [
    stages_1,
]

custom_workflow_input = LaunchDarklyClient::CustomWorkflowInput.new
custom_workflow_input.name = "Progressive rollout starting in two days"
custom_workflow_input.description = "Turn flag on for 10% of customers each day"
custom_workflow_input.stages = stages

begin
    response = LaunchDarklyClient::WorkflowsApi.new.post_workflow(
        "projectKey_string", # project_key
        "featureFlagKey_string", # feature_flag_key
        "environmentKey_string", # environment_key
        custom_workflow_input,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling WorkflowsApi#post_workflow: #{e}"
end
