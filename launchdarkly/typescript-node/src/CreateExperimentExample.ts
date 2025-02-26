import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ExperimentsApi();
apiCaller.setApiKey(api.ExperimentsApiApiKeys.ApiKey, "YOUR_API_KEY");

const iterationTreatments1Parameters1 = new models.TreatmentParameterInput();
iterationTreatments1Parameters1.flagKey = "example-flag-for-experiment";
iterationTreatments1Parameters1.variationId = "e432f62b-55f6-49dd-a02f-eb24acf39d05";

const iterationTreatments1Parameters = [
  iterationTreatments1Parameters1,
];

const iterationMetrics1 = new models.MetricInput();
iterationMetrics1.key = "metric-key-123abc";
iterationMetrics1.isGroup = true;
iterationMetrics1.primary = true;

const iterationMetrics = [
  iterationMetrics1,
];

const iterationTreatments1 = new models.TreatmentInput();
iterationTreatments1.name = "Treatment 1";
iterationTreatments1.baseline = true;
iterationTreatments1.allocationPercent = "10";
iterationTreatments1.parameters = iterationTreatments1Parameters;

const iterationTreatments = [
  iterationTreatments1,
];

const iteration = new models.IterationInput();
iteration.hypothesis = "Example hypothesis, the new button placement will increase conversion";
iteration.flags = undefined;
iteration.canReshuffleTraffic = true;
iteration.primarySingleMetricKey = "metric-key-123abc";
iteration.primaryFunnelKey = "metric-group-key-123abc";
iteration.randomizationUnit = "user";
iteration.attributes = [
  "country",
  "device",
  "os",
];
iteration.metrics = iterationMetrics;
iteration.treatments = iterationTreatments;

const experimentPost = new models.ExperimentPost();
experimentPost.name = "Example experiment";
experimentPost.key = "experiment-key-123abc";
experimentPost.description = "An example experiment, used in testing";
experimentPost.maintainerId = "12ab3c45de678910fgh12345";
experimentPost.holdoutId = "f3b74309-d581-44e1-8a2b-bb2933b4fe40";
experimentPost.iteration = iteration;

apiCaller.createExperiment(
  undefined, // projectKey
  undefined, // environmentKey
  experimentPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ExperimentsApi#createExperiment:");
  console.log(error.body);
});
