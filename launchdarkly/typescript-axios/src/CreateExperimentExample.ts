import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const iterationTreatments1Parameters1: api.TreatmentParameterInput = {
  flagKey: "example-flag-for-experiment",
  variationId: "e432f62b-55f6-49dd-a02f-eb24acf39d05",
};

const iterationTreatments1Parameters = [
  iterationTreatments1Parameters1,
];

const iterationMetrics1: api.MetricInput = {
  key: "metric-key-123abc",
  isGroup: true,
  primary: true,
};

const iterationMetrics = [
  iterationMetrics1,
];

const iterationTreatments1: api.TreatmentInput = {
  name: "Treatment 1",
  baseline: true,
  allocationPercent: "10",
  parameters: iterationTreatments1Parameters,
};

const iterationTreatments = [
  iterationTreatments1,
];

const iteration: api.IterationInput = {
  hypothesis: "Example hypothesis, the new button placement will increase conversion",
  flags: {},
  canReshuffleTraffic: true,
  primarySingleMetricKey: "metric-key-123abc",
  primaryFunnelKey: "metric-group-key-123abc",
  randomizationUnit: "user",
  attributes: [
    "country",
    "device",
    "os",
  ],
  metrics: iterationMetrics,
  treatments: iterationTreatments,
};

const experimentPost: api.ExperimentPost = {
  name: "Example experiment",
  key: "experiment-key-123abc",
  description: "An example experiment, used in testing",
  maintainerId: "12ab3c45de678910fgh12345",
  holdoutId: "f3b74309-d581-44e1-8a2b-bb2933b4fe40",
  iteration: iteration,
};

new api.ExperimentsApi(configuration).createExperiment(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  experimentPost,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ExperimentsApi#createExperiment:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
