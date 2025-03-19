import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.MessagesApi();
apiCaller.setApiKey(api.MessagesApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.MessagesApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");

const templateParams: models.ConversationMessageCreateTemplateParams = {
  name: "sample_issue_resolution",
  category: "UTILITY",
  language: "en_US",
  processedParams: {
    "1": "Chatwoot"
  },
};

const conversationMessageCreate: models.ConversationMessageCreate = {
  content: "content_string",
  contentType: models.ConversationMessageCreate.ContentTypeEnum.Cards,
  templateParams: templateParams,
};

apiCaller.createANewMessageInAConversation(
  0, // accountId
  0, // conversationId
  conversationMessageCreate, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling MessagesApi#createANewMessageInAConversation:");
  console.log(error.body);
});
