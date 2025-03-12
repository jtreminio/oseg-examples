import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.AgentsApi();
apiCaller.setApiKey(api.AgentsApiApiKeys.userApiKey, "USER_API_KEY");

apiCaller.getAccountAgents(
  undefined, // accountId
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AgentsApi#getAccountAgents:");
  console.log(error.body);
});
