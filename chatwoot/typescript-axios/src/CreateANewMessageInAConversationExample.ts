import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
  // apiKey: "AGENT_BOT_API_KEY",
});

const templateParams: api.NewConversationRequestMessageTemplateParams = {
  name: "sample_issue_resolution",
  category: "UTILITY",
  language: "en_US",
  processed_params: {
    "1": "Chatwoot"
  },
};

const conversationMessageCreate: api.ConversationMessageCreate = {
  content: "content_string",
  content_type: api.ConversationMessageCreateContentTypeEnum.Cards,
  template_params: templateParams,
};

new api.MessagesApi(configuration).createANewMessageInAConversation(
  0, // accountId
  0, // conversationId
  conversationMessageCreate, // data
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling MessagesApi#createANewMessageInAConversation:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
