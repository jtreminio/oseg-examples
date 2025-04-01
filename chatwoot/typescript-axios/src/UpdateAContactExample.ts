import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
});

const publicContactCreateUpdatePayload: api.PublicContactCreateUpdatePayload = {
};

new api.ContactsAPIApi(configuration).updateAContact(
  "inbox_identifier_string", // inboxIdentifier
  "contact_identifier_string", // contactIdentifier
  publicContactCreateUpdatePayload, // data
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ContactsAPIApi#updateAContact:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
