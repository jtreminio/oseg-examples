import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.InsightsChartsBetaApi();
apiCaller.setApiKey(api.InsightsChartsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getDeploymentFrequencyChart().then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling InsightsChartsBetaApi#getDeploymentFrequencyChart:");
  console.log(error.body);
});
