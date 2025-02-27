require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

treatments_1_parameters_1 = LaunchDarklyClient::TreatmentParameterInput.new
treatments_1_parameters_1.flag_key = "example-flag-for-experiment"
treatments_1_parameters_1.variation_id = "e432f62b-55f6-49dd-a02f-eb24acf39d05"

treatments_1_parameters = [
    treatments_1_parameters_1,
]

metrics_1 = LaunchDarklyClient::MetricInput.new
metrics_1.key = "metric-key-123abc"
metrics_1.is_group = true
metrics_1.primary = true

metrics = [
    metrics_1,
]

treatments_1 = LaunchDarklyClient::TreatmentInput.new
treatments_1.name = "Treatment 1"
treatments_1.baseline = true
treatments_1.allocation_percent = "10"
treatments_1.parameters = treatments_1_parameters

treatments = [
    treatments_1,
]

iteration_input = LaunchDarklyClient::IterationInput.new
iteration_input.hypothesis = "Example hypothesis, the new button placement will increase conversion"
iteration_input.flags = nil
iteration_input.can_reshuffle_traffic = true
iteration_input.primary_single_metric_key = "metric-key-123abc"
iteration_input.primary_funnel_key = "metric-group-key-123abc"
iteration_input.randomization_unit = "user"
iteration_input.attributes = [
    "country",
    "device",
    "os",
]
iteration_input.metrics = metrics
iteration_input.treatments = treatments

begin
    response = LaunchDarklyClient::ExperimentsApi.new.create_iteration(
        nil, # project_key
        nil, # environment_key
        nil, # experiment_key
        iteration_input,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ExperimentsApi#create_iteration: #{e}"
end
