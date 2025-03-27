import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.ConversationLabelsApi();
apiCaller.setApiKey(api.ConversationLabelsApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.ConversationLabelsApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");
// apiCaller.setApiKey(api.ConversationLabelsApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

apiCaller.listAllLabelsOfAConversation(
  0, // accountId
  0, // conversationId
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ConversationLabelsApi#listAllLabelsOfAConversation:");
  console.log(error.body);
});
