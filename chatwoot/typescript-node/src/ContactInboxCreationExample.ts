import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.ContactApi();
apiCaller.setApiKey(api.ContactApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.ContactApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");
// apiCaller.setApiKey(api.ContactApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

const contactInboxCreationRequest: models.ContactInboxCreationRequest = {
  inboxId: 0,
};

apiCaller.contactInboxCreation(
  0, // accountId
  0, // id
  contactInboxCreationRequest, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ContactApi#contactInboxCreation:");
  console.log(error.body);
});
