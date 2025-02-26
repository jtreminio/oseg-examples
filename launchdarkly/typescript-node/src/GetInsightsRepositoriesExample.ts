import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.InsightsRepositoriesBetaApi();
apiCaller.setApiKey(api.InsightsRepositoriesBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getInsightsRepositories().then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling InsightsRepositoriesBetaApi#getInsightsRepositories:");
  console.log(error.body);
});
