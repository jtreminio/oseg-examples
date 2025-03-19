import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.InboxesApi();
apiCaller.setApiKey(api.InboxesApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.InboxesApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");
// apiCaller.setApiKey(api.InboxesApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

const inboxCreationRequest: models.InboxCreationRequest = {
};

apiCaller.inboxCreation(
  0, // accountId
  inboxCreationRequest, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling InboxesApi#inboxCreation:");
  console.log(error.body);
});
