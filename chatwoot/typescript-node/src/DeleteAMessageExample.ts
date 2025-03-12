import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.MessagesApi();
apiCaller.setApiKey(api.MessagesApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.MessagesApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");
// apiCaller.setApiKey(api.MessagesApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

apiCaller.deleteAMessage(
  undefined, // accountId
  undefined, // conversationId
  undefined, // messageId
).catch(error => {
  console.log("Exception when calling MessagesApi#deleteAMessage:");
  console.log(error.body);
});
