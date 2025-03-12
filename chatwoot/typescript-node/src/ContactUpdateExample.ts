import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.ContactsApi();
apiCaller.setApiKey(api.ContactsApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.ContactsApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");
// apiCaller.setApiKey(api.ContactsApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

const contactUpdate = new models.ContactUpdate();
contactUpdate.name = undefined;
contactUpdate.email = undefined;
contactUpdate.phoneNumber = undefined;
contactUpdate.avatarUrl = undefined;
contactUpdate.identifier = undefined;
contactUpdate.avatar = undefined;

apiCaller.contactUpdate(
  undefined, // accountId
  undefined, // id
  contactUpdate, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ContactsApi#contactUpdate:");
  console.log(error.body);
});
