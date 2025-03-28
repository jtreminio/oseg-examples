import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
});

const publicMessageCreatePayload: api.PublicMessageCreatePayload = {
};

new api.MessagesAPIApi(configuration).createAMessage(
  "inbox_identifier_string", // inboxIdentifier
  "contact_identifier_string", // contactIdentifier
  0, // conversationId
  publicMessageCreatePayload, // data
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling MessagesAPIApi#createAMessage:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
