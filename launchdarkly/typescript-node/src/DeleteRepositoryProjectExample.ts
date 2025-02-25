import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.InsightsRepositoriesBetaApi();
apiCaller.setApiKey(api.InsightsRepositoriesBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteRepositoryProject(
  undefined, // repositoryKey
  undefined, // projectKey
).catch(error => {
  console.log("Exception when calling InsightsRepositoriesBeta#deleteRepositoryProject:");
  console.log(error.body);
});
