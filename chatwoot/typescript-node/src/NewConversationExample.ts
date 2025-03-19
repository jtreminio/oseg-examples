import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.ConversationsApi();
apiCaller.setApiKey(api.ConversationsApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.ConversationsApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");

const messageTemplateParams: models.NewConversationRequestMessageTemplateParams = {
  name: "sample_issue_resolution",
  category: "UTILITY",
  language: "en_US",
  processedParams: {
    "1": "Chatwoot"
  },
};

const message: models.NewConversationRequestMessage = {
  content: "content_string",
  templateParams: messageTemplateParams,
};

const newConversationRequest: models.NewConversationRequest = {
  inboxId: "inbox_id_string",
  sourceId: "source_id_string",
  customAttributes: {
    "attribute_key": "attribute_value",
    "priority_conversation_number": 3
  },
  message: message,
};

apiCaller.newConversation(
  0, // accountId
  newConversationRequest, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ConversationsApi#newConversation:");
  console.log(error.body);
});
