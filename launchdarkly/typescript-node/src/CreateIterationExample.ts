import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ExperimentsApi();
apiCaller.setApiKey(api.ExperimentsApiApiKeys.ApiKey, "YOUR_API_KEY");

const treatments1Parameters1 = new models.TreatmentParameterInput();
treatments1Parameters1.flagKey = "example-flag-for-experiment";
treatments1Parameters1.variationId = "e432f62b-55f6-49dd-a02f-eb24acf39d05";

const treatments1Parameters = [
  treatments1Parameters1,
];

const metrics1 = new models.MetricInput();
metrics1.key = "metric-key-123abc";
metrics1.isGroup = true;
metrics1.primary = true;

const metrics = [
  metrics1,
];

const treatments1 = new models.TreatmentInput();
treatments1.name = "Treatment 1";
treatments1.baseline = true;
treatments1.allocationPercent = "10";
treatments1.parameters = treatments1Parameters;

const treatments = [
  treatments1,
];

const iterationInput = new models.IterationInput();
iterationInput.hypothesis = "Example hypothesis, the new button placement will increase conversion";
iterationInput.flags = undefined;
iterationInput.canReshuffleTraffic = true;
iterationInput.primarySingleMetricKey = "metric-key-123abc";
iterationInput.primaryFunnelKey = "metric-group-key-123abc";
iterationInput.randomizationUnit = "user";
iterationInput.attributes = [
  "country",
  "device",
  "os",
];
iterationInput.metrics = metrics;
iterationInput.treatments = treatments;

apiCaller.createIteration(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // experimentKey
  iterationInput,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ExperimentsApi#createIteration:");
  console.log(error.body);
});
