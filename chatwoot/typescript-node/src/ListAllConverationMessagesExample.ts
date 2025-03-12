import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.MessagesAPIApi();
apiCaller.setApiKey(api.MessagesAPIApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.MessagesAPIApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");
// apiCaller.setApiKey(api.MessagesAPIApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

apiCaller.listAllConverationMessages(
  undefined, // inboxIdentifier
  undefined, // contactIdentifier
  undefined, // conversationId
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling MessagesAPIApi#listAllConverationMessages:");
  console.log(error.body);
});
