import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
  // apiKey: "AGENT_BOT_API_KEY",
  // apiKey: "PLATFORM_APP_API_KEY",
});

new api.ConversationsApi(configuration).conversationList(
  0, // accountId
  "all", // assigneeType
  "open", // status
  undefined, // q
  undefined, // inboxId
  undefined, // teamId
  undefined, // labels
  1, // page
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ConversationsApi#conversationList:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
