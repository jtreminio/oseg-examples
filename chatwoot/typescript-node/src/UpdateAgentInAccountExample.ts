import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.AgentsApi();
apiCaller.setApiKey(api.AgentsApiApiKeys.userApiKey, "USER_API_KEY");

const updateAgentInAccountRequest = new models.UpdateAgentInAccountRequest();
updateAgentInAccountRequest.role = undefined;
updateAgentInAccountRequest.availability = undefined;
updateAgentInAccountRequest.autoOffline = undefined;

apiCaller.updateAgentInAccount(
  undefined, // accountId
  undefined, // id
  updateAgentInAccountRequest, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AgentsApi#updateAgentInAccount:");
  console.log(error.body);
});
