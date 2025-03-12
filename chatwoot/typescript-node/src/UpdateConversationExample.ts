import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.ConversationsApi();
apiCaller.setApiKey(api.ConversationsApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.ConversationsApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");

const updateConversationRequest = new models.UpdateConversationRequest();
updateConversationRequest.priority = undefined;
updateConversationRequest.slaPolicyId = undefined;

apiCaller.updateConversation(
  undefined, // accountId
  undefined, // conversationId
  updateConversationRequest, // data
).catch(error => {
  console.log("Exception when calling ConversationsApi#updateConversation:");
  console.log(error.body);
});
