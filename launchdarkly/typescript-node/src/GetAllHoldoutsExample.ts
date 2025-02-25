import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.HoldoutsBetaApi();
apiCaller.setApiKey(api.HoldoutsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getAllHoldouts(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // limit
  undefined, // offset
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling HoldoutsBeta#getAllHoldouts:");
  console.log(error.body);
});
