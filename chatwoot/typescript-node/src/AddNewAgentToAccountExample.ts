import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.AgentsApi();
apiCaller.setApiKey(api.AgentsApiApiKeys.userApiKey, "USER_API_KEY");

const addNewAgentToAccountRequest = new models.AddNewAgentToAccountRequest();
addNewAgentToAccountRequest.email = undefined;
addNewAgentToAccountRequest.name = undefined;
addNewAgentToAccountRequest.role = undefined;
addNewAgentToAccountRequest.availabilityStatus = undefined;
addNewAgentToAccountRequest.autoOffline = undefined;

apiCaller.addNewAgentToAccount(
  undefined, // accountId
  addNewAgentToAccountRequest, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AgentsApi#addNewAgentToAccount:");
  console.log(error.body);
});
