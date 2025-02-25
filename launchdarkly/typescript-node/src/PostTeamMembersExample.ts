import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.TeamsApi();
apiCaller.setApiKey(api.TeamsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.postTeamMembers(
  undefined, // teamKey
  undefined, // file
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling Teams#postTeamMembers:");
  console.log(error.body);
});
