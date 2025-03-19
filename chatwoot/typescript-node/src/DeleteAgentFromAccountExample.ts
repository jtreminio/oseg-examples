import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.AgentsApi();
apiCaller.setApiKey(api.AgentsApiApiKeys.userApiKey, "USER_API_KEY");

apiCaller.deleteAgentFromAccount(
  0, // accountId
  0, // id
).catch(error => {
  console.log("Exception when calling AgentsApi#deleteAgentFromAccount:");
  console.log(error.body);
});
