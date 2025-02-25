import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ExperimentsApi();
apiCaller.setApiKey(api.ExperimentsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getExperimentResultsForMetricGroup(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // experimentKey
  undefined, // metricGroupKey
  undefined, // iterationId
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling Experiments#getExperimentResultsForMetricGroup:");
  console.log(error.body);
});
