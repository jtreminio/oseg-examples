import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.TeamsApi();
apiCaller.setApiKey(api.TeamsApiApiKeys.userApiKey, "USER_API_KEY");

apiCaller.getTeamMembers(
  undefined, // accountId
  undefined, // teamId
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling TeamsApi#getTeamMembers:");
  console.log(error.body);
});
