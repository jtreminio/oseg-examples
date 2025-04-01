import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
});

const publicMessageUpdatePayload: api.PublicMessageUpdatePayload = {
};

new api.MessagesAPIApi(configuration).updateAMessage(
  "inbox_identifier_string", // inboxIdentifier
  "contact_identifier_string", // contactIdentifier
  0, // conversationId
  0, // messageId
  publicMessageUpdatePayload, // data
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling MessagesAPIApi#updateAMessage:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
