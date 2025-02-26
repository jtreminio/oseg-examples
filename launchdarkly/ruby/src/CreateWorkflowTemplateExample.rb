require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
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
stages_1.execute_conditions_in_sequence = true
stages_1.action = stages_1_action
stages_1.conditions = stages_1_conditions

stages = [
    stages_1,
]

create_workflow_template_input = LaunchDarklyClient::CreateWorkflowTemplateInput.new
create_workflow_template_input.key = nil
create_workflow_template_input.name = nil
create_workflow_template_input.description = nil
create_workflow_template_input.workflow_id = nil
create_workflow_template_input.project_key = nil
create_workflow_template_input.environment_key = nil
create_workflow_template_input.flag_key = nil
create_workflow_template_input.stages = stages

begin
    response = LaunchDarklyClient::WorkflowTemplatesApi.new.create_workflow_template(
        create_workflow_template_input,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling WorkflowTemplatesApi#create_workflow_template: #{e}"
end
