import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.ContactsApi();
apiCaller.setApiKey(api.ContactsApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.ContactsApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");
// apiCaller.setApiKey(api.ContactsApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

const contactCreate = new models.ContactCreate();
contactCreate.inboxId = undefined;
contactCreate.name = undefined;
contactCreate.email = undefined;
contactCreate.phoneNumber = undefined;
contactCreate.avatarUrl = undefined;
contactCreate.identifier = undefined;
contactCreate.avatar = undefined;

apiCaller.contactCreate(
  undefined, // accountId
  contactCreate, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ContactsApi#contactCreate:");
  console.log(error.body);
});
