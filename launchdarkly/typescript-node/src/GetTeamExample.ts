import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.TeamsApi();
apiCaller.setApiKey(api.TeamsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getTeam(
  "teamKey_string", // teamKey
  undefined, // expand
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling TeamsApi#getTeam:");
  console.log(error.body);
});
