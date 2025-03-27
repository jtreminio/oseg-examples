import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.ContactLabelsApi();
apiCaller.setApiKey(api.ContactLabelsApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.ContactLabelsApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");
// apiCaller.setApiKey(api.ContactLabelsApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

apiCaller.listAllLabelsOfAContact(
  0, // accountId
  "contact_identifier_string", // contactIdentifier
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ContactLabelsApi#listAllLabelsOfAContact:");
  console.log(error.body);
});
