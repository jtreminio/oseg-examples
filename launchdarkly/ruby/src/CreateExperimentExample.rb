require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

iteration_treatments_1_parameters_1 = LaunchDarklyClient::TreatmentParameterInput.new
iteration_treatments_1_parameters_1.flag_key = "example-flag-for-experiment"
iteration_treatments_1_parameters_1.variation_id = "e432f62b-55f6-49dd-a02f-eb24acf39d05"

iteration_treatments_1_parameters = [
    iteration_treatments_1_parameters_1,
]

iteration_metrics_1 = LaunchDarklyClient::MetricInput.new
iteration_metrics_1.key = "metric-key-123abc"
iteration_metrics_1.is_group = true
iteration_metrics_1.primary = true

iteration_metrics = [
    iteration_metrics_1,
]

iteration_treatments_1 = LaunchDarklyClient::TreatmentInput.new
iteration_treatments_1.name = "Treatment 1"
iteration_treatments_1.baseline = true
iteration_treatments_1.allocation_percent = "10"
iteration_treatments_1.parameters = iteration_treatments_1_parameters

iteration_treatments = [
    iteration_treatments_1,
]

iteration = LaunchDarklyClient::IterationInput.new
iteration.hypothesis = "Example hypothesis, the new button placement will increase conversion"
iteration.flags = {}
iteration.can_reshuffle_traffic = true
iteration.primary_single_metric_key = "metric-key-123abc"
iteration.primary_funnel_key = "metric-group-key-123abc"
iteration.randomization_unit = "user"
iteration.attributes = [
    "country",
    "device",
    "os",
]
iteration.metrics = iteration_metrics
iteration.treatments = iteration_treatments

experiment_post = LaunchDarklyClient::ExperimentPost.new
experiment_post.name = "Example experiment"
experiment_post.key = "experiment-key-123abc"
experiment_post.description = "An example experiment, used in testing"
experiment_post.maintainer_id = "12ab3c45de678910fgh12345"
experiment_post.holdout_id = "f3b74309-d581-44e1-8a2b-bb2933b4fe40"
experiment_post.iteration = iteration

begin
    response = LaunchDarklyClient::ExperimentsApi.new.create_experiment(
        "projectKey_string", # project_key
        "environmentKey_string", # environment_key
        experiment_post,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ExperimentsApi#create_experiment: #{e}"
end
