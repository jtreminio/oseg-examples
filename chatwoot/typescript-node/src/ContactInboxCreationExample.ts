import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.ContactApi();
apiCaller.setApiKey(api.ContactApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.ContactApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");
// apiCaller.setApiKey(api.ContactApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

const contactInboxCreationRequest = new models.ContactInboxCreationRequest();
contactInboxCreationRequest.inboxId = undefined;
contactInboxCreationRequest.sourceId = undefined;

apiCaller.contactInboxCreation(
  undefined, // accountId
  undefined, // id
  contactInboxCreationRequest, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ContactApi#contactInboxCreation:");
  console.log(error.body);
});
