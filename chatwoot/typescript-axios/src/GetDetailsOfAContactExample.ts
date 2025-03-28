import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
});

new api.ContactsAPIApi(configuration).getDetailsOfAContact(
  "inbox_identifier_string", // inboxIdentifier
  "contact_identifier_string", // contactIdentifier
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ContactsAPIApi#getDetailsOfAContact:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
