import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
  // apiKey: "AGENT_BOT_API_KEY",
});

const togglePriorityOfAConversationRequest: api.TogglePriorityOfAConversationRequest = {
  priority: api.TogglePriorityOfAConversationRequestPriorityEnum.Urgent,
};

new api.ConversationsApi(configuration).togglePriorityOfAConversation(
  0, // accountId
  0, // conversationId
  togglePriorityOfAConversationRequest, // data
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ConversationsApi#togglePriorityOfAConversation:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
