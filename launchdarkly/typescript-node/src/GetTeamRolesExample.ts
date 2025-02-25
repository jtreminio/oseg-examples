import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.TeamsApi();
apiCaller.setApiKey(api.TeamsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getTeamRoles(
  undefined, // teamKey
  undefined, // limit
  undefined, // offset
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling Teams#getTeamRoles:");
  console.log(error.body);
});
