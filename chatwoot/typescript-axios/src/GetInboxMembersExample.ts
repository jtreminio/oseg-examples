import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
});

new api.InboxesApi(configuration).getInboxMembers(
  0, // accountId
  0, // inboxId
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling InboxesApi#getInboxMembers:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
