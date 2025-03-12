import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.ConversationAssignmentApi();
apiCaller.setApiKey(api.ConversationAssignmentApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.ConversationAssignmentApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");

const assignAConversationRequest = new models.AssignAConversationRequest();
assignAConversationRequest.assigneeId = undefined;
assignAConversationRequest.teamId = undefined;

apiCaller.assignAConversation(
  undefined, // accountId
  undefined, // conversationId
  assignAConversationRequest, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ConversationAssignmentApi#assignAConversation:");
  console.log(error.body);
});
