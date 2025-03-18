import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ApplicationsBetaApi();
apiCaller.setApiKey(api.ApplicationsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getApplicationVersions(
  "applicationKey_string", // applicationKey
  undefined, // filter
  undefined, // limit
  undefined, // offset
  undefined, // sort
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ApplicationsBetaApi#getApplicationVersions:");
  console.log(error.body);
});
