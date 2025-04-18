import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.ConversationsApi();
apiCaller.setApiKey(api.ConversationsApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.ConversationsApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");

const toggleStatusOfAConversationRequest: models.ToggleStatusOfAConversationRequest = {
  status: models.ToggleStatusOfAConversationRequest.StatusEnum.Open,
};

apiCaller.toggleStatusOfAConversation(
  0, // accountId
  0, // conversationId
  toggleStatusOfAConversationRequest, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ConversationsApi#toggleStatusOfAConversation:");
  console.log(error.body);
});
