import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.InsightsChartsBetaApi();
apiCaller.setApiKey(api.InsightsChartsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getStaleFlagsChart(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // applicationKey
  undefined, // groupBy
  undefined, // maintainerId
  undefined, // maintainerTeamKey
  undefined, // expand
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling InsightsChartsBeta#getStaleFlagsChart:");
  console.log(error.body);
});
