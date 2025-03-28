import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
  // apiKey: "AGENT_BOT_API_KEY",
});

const messageTemplateParams: api.NewConversationRequestMessageTemplateParams = {
  name: "sample_issue_resolution",
  category: "UTILITY",
  language: "en_US",
  processed_params: {
    "1": "Chatwoot"
  },
};

const message: api.NewConversationRequestMessage = {
  content: "content_string",
  template_params: messageTemplateParams,
};

const newConversationRequest: api.NewConversationRequest = {
  inbox_id: "inbox_id_string",
  source_id: "source_id_string",
  custom_attributes: {
    "attribute_key": "attribute_value",
    "priority_conversation_number": 3
  },
  message: message,
};

new api.ConversationsApi(configuration).newConversation(
  0, // accountId
  newConversationRequest, // data
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ConversationsApi#newConversation:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
