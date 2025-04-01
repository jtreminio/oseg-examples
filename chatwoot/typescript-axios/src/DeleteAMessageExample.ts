import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
  // apiKey: "AGENT_BOT_API_KEY",
  // apiKey: "PLATFORM_APP_API_KEY",
});

new api.MessagesApi(configuration).deleteAMessage(
  0, // accountId
  0, // conversationId
  0, // messageId
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling MessagesApi#deleteAMessage:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
