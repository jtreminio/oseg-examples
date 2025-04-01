import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
  // apiKey: "AGENT_BOT_API_KEY",
});

const toggleStatusOfAConversationRequest: api.ToggleStatusOfAConversationRequest = {
  status: api.ToggleStatusOfAConversationRequestStatusEnum.Open,
};

new api.ConversationsApi(configuration).toggleStatusOfAConversation(
  0, // accountId
  0, // conversationId
  toggleStatusOfAConversationRequest, // data
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ConversationsApi#toggleStatusOfAConversation:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
