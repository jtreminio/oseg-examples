import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.TeamsApi();
apiCaller.setApiKey(api.TeamsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteTeam(
  undefined, // teamKey
).catch(error => {
  console.log("Exception when calling TeamsApi#deleteTeam:");
  console.log(error.body);
});
