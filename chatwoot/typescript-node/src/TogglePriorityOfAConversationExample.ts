import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.ConversationsApi();
apiCaller.setApiKey(api.ConversationsApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.ConversationsApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");

const togglePriorityOfAConversationRequest = new models.TogglePriorityOfAConversationRequest();
togglePriorityOfAConversationRequest.priority = undefined;

apiCaller.togglePriorityOfAConversation(
  undefined, // accountId
  undefined, // conversationId
  togglePriorityOfAConversationRequest, // data
).catch(error => {
  console.log("Exception when calling ConversationsApi#togglePriorityOfAConversation:");
  console.log(error.body);
});
