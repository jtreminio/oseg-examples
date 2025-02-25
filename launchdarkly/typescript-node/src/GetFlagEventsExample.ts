import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.InsightsFlagEventsBetaApi();
apiCaller.setApiKey(api.InsightsFlagEventsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getFlagEvents(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // applicationKey
  undefined, // query
  undefined, // impactSize
  undefined, // hasExperiments
  undefined, // global
  undefined, // expand
  undefined, // limit
  undefined, // from
  undefined, // to
  undefined, // after
  undefined, // before
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling InsightsFlagEventsBeta#getFlagEvents:");
  console.log(error.body);
});
