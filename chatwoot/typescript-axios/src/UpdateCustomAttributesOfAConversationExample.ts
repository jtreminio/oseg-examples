import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
  // apiKey: "AGENT_BOT_API_KEY",
});

const updateCustomAttributesOfAConversationRequest: api.UpdateCustomAttributesOfAConversationRequest = {
  custom_attributes: {
    "order_id": "12345",
    "previous_conversation": "67890"
  },
};

new api.ConversationsApi(configuration).updateCustomAttributesOfAConversation(
  0, // accountId
  0, // conversationId
  updateCustomAttributesOfAConversationRequest, // data
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ConversationsApi#updateCustomAttributesOfAConversation:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
