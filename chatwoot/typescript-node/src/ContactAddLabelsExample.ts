import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.ContactLabelsApi();
apiCaller.setApiKey(api.ContactLabelsApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.ContactLabelsApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");
// apiCaller.setApiKey(api.ContactLabelsApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

const contactAddLabelsRequest: models.ContactAddLabelsRequest = {
  labels: [
  ],
};

apiCaller.contactAddLabels(
  0, // accountId
  "contact_identifier_string", // contactIdentifier
  contactAddLabelsRequest, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ContactLabelsApi#contactAddLabels:");
  console.log(error.body);
});
