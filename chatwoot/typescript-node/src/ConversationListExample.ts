import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.ConversationsApi();
apiCaller.setApiKey(api.ConversationsApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.ConversationsApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");
// apiCaller.setApiKey(api.ConversationsApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

apiCaller.conversationList(
  undefined, // accountId
  "all", // assigneeType
  "open", // status
  undefined, // q
  undefined, // inboxId
  undefined, // teamId
  undefined, // labels
  1, // page
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ConversationsApi#conversationList:");
  console.log(error.body);
});
