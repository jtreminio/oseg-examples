import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
  // apiKey: "AGENT_BOT_API_KEY",
});

const assignAConversationRequest: api.AssignAConversationRequest = {
};

new api.ConversationAssignmentApi(configuration).assignAConversation(
  0, // accountId
  0, // conversationId
  assignAConversationRequest, // data
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ConversationAssignmentApi#assignAConversation:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
