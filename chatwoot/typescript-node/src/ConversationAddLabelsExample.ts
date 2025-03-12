import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.ConversationLabelsApi();
apiCaller.setApiKey(api.ConversationLabelsApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.ConversationLabelsApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");
// apiCaller.setApiKey(api.ConversationLabelsApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

const conversationAddLabelsRequest = new models.ConversationAddLabelsRequest();
conversationAddLabelsRequest.labels = [
];

apiCaller.conversationAddLabels(
  undefined, // accountId
  undefined, // conversationId
  conversationAddLabelsRequest, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ConversationLabelsApi#conversationAddLabels:");
  console.log(error.body);
});
