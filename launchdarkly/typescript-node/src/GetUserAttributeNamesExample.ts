import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.UsersBetaApi();
apiCaller.setApiKey(api.UsersBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getUserAttributeNames(
  undefined, // projectKey
  undefined, // environmentKey
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling UsersBeta#getUserAttributeNames:");
  console.log(error.body);
});
