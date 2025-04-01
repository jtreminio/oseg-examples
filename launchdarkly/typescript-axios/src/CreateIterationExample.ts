import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const treatments1Parameters1: api.TreatmentParameterInput = {
  flagKey: "example-flag-for-experiment",
  variationId: "e432f62b-55f6-49dd-a02f-eb24acf39d05",
};

const treatments1Parameters = [
  treatments1Parameters1,
];

const metrics1: api.MetricInput = {
  key: "metric-key-123abc",
  isGroup: true,
  primary: true,
};

const metrics = [
  metrics1,
];

const treatments1: api.TreatmentInput = {
  name: "Treatment 1",
  baseline: true,
  allocationPercent: "10",
  parameters: treatments1Parameters,
};

const treatments = [
  treatments1,
];

const iterationInput: api.IterationInput = {
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
  metrics: metrics,
  treatments: treatments,
};

new api.ExperimentsApi(configuration).createIteration(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "experimentKey_string", // experimentKey
  iterationInput,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ExperimentsApi#createIteration:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
