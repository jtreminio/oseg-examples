import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.AgentsApi();
apiCaller.setApiKey(api.AgentsApiApiKeys.userApiKey, "USER_API_KEY");

const updateAgentInAccountRequest: models.UpdateAgentInAccountRequest = {
  role: models.UpdateAgentInAccountRequest.RoleEnum.Agent,
};

apiCaller.updateAgentInAccount(
  0, // accountId
  0, // id
  updateAgentInAccountRequest, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AgentsApi#updateAgentInAccount:");
  console.log(error.body);
});
