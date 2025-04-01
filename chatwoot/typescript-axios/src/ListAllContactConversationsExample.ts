import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
  // apiKey: "AGENT_BOT_API_KEY",
  // apiKey: "PLATFORM_APP_API_KEY",
});

new api.ConversationsAPIApi(configuration).listAllContactConversations(
  "inbox_identifier_string", // inboxIdentifier
  "contact_identifier_string", // contactIdentifier
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ConversationsAPIApi#listAllContactConversations:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
