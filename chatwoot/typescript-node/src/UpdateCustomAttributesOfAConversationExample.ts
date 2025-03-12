import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.ConversationsApi();
apiCaller.setApiKey(api.ConversationsApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.ConversationsApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");

const updateCustomAttributesOfAConversationRequest = new models.UpdateCustomAttributesOfAConversationRequest();

apiCaller.updateCustomAttributesOfAConversation(
  undefined, // accountId
  undefined, // conversationId
  updateCustomAttributesOfAConversationRequest, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ConversationsApi#updateCustomAttributesOfAConversation:");
  console.log(error.body);
});
