import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.EnvironmentsApi();
apiCaller.setApiKey(api.EnvironmentsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getEnvironmentsByProject(
  "projectKey_string", // projectKey
  undefined, // limit
  undefined, // offset
  undefined, // filter
  undefined, // sort
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling EnvironmentsApi#getEnvironmentsByProject:");
  console.log(error.body);
});
