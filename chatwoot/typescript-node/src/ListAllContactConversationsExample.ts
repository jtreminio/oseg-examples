import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.ConversationsAPIApi();
apiCaller.setApiKey(api.ConversationsAPIApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.ConversationsAPIApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");
// apiCaller.setApiKey(api.ConversationsAPIApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

apiCaller.listAllContactConversations(
  "inbox_identifier_string", // inboxIdentifier
  "contact_identifier_string", // contactIdentifier
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ConversationsAPIApi#listAllContactConversations:");
  console.log(error.body);
});
