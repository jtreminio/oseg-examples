import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
});

new api.InboxAPIApi(configuration).getDetailsOfAInbox(
  "inbox_identifier_string", // inboxIdentifier
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling InboxAPIApi#getDetailsOfAInbox:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
