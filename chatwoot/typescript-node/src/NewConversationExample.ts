import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.ConversationsApi();
apiCaller.setApiKey(api.ConversationsApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.ConversationsApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");

const messageTemplateParams = new models.NewConversationRequestMessageTemplateParams();
messageTemplateParams.name = "sample_issue_resolution";
messageTemplateParams.category = "UTILITY";
messageTemplateParams.language = "en_US";

const message = new models.NewConversationRequestMessage();
message.content = undefined;
message.templateParams = messageTemplateParams;

const newConversationRequest = new models.NewConversationRequest();
newConversationRequest.inboxId = undefined;
newConversationRequest.sourceId = undefined;
newConversationRequest.contactId = undefined;
newConversationRequest.status = undefined;
newConversationRequest.assigneeId = undefined;
newConversationRequest.teamId = undefined;
newConversationRequest.message = message;

apiCaller.newConversation(
  undefined, // accountId
  newConversationRequest, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ConversationsApi#newConversation:");
  console.log(error.body);
});
