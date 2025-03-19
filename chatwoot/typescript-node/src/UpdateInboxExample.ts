import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.InboxesApi();
apiCaller.setApiKey(api.InboxesApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.InboxesApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");
// apiCaller.setApiKey(api.InboxesApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

const updateInboxRequest: models.UpdateInboxRequest = {
  enableAutoAssignment: false,
};

apiCaller.updateInbox(
  0, // accountId
  0, // id
  updateInboxRequest, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling InboxesApi#updateInbox:");
  console.log(error.body);
});
