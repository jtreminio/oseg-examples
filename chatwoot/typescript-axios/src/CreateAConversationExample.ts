import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
});

const publicConversationCreatePayload: api.PublicConversationCreatePayload = {
};

new api.ConversationsAPIApi(configuration).createAConversation(
  "inbox_identifier_string", // inboxIdentifier
  "contact_identifier_string", // contactIdentifier
  publicConversationCreatePayload, // data
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ConversationsAPIApi#createAConversation:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
