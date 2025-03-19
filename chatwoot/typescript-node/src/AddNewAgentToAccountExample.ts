import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.AgentsApi();
apiCaller.setApiKey(api.AgentsApiApiKeys.userApiKey, "USER_API_KEY");

const addNewAgentToAccountRequest: models.AddNewAgentToAccountRequest = {
  email: "email_string",
  name: "name_string",
  role: models.AddNewAgentToAccountRequest.RoleEnum.Agent,
};

apiCaller.addNewAgentToAccount(
  0, // accountId
  addNewAgentToAccountRequest, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AgentsApi#addNewAgentToAccount:");
  console.log(error.body);
});
