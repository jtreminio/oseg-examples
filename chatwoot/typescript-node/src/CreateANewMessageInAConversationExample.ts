import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.MessagesApi();
apiCaller.setApiKey(api.MessagesApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.MessagesApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");

const templateParams = new models.ConversationMessageCreateTemplateParams();
templateParams.name = "sample_issue_resolution";
templateParams.category = "UTILITY";
templateParams.language = "en_US";

const conversationMessageCreate = new models.ConversationMessageCreate();
conversationMessageCreate.content = undefined;
conversationMessageCreate.messageType = undefined;
conversationMessageCreate._private = undefined;
conversationMessageCreate.contentType = models.ConversationMessageCreate.ContentTypeEnum.Cards;
conversationMessageCreate.templateParams = templateParams;

apiCaller.createANewMessageInAConversation(
  undefined, // accountId
  undefined, // conversationId
  conversationMessageCreate, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling MessagesApi#createANewMessageInAConversation:");
  console.log(error.body);
});
