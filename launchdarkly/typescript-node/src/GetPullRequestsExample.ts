import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.InsightsPullRequestsBetaApi();
apiCaller.setApiKey(api.InsightsPullRequestsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getPullRequests(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // applicationKey
  undefined, // status
  undefined, // query
  undefined, // limit
  undefined, // expand
  undefined, // sort
  new Date("None"), // from
  new Date("None"), // to
  undefined, // after
  undefined, // before
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling InsightsPullRequestsBeta#getPullRequests:");
  console.log(error.body);
});
