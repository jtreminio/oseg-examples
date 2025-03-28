import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
  // apiKey: "AGENT_BOT_API_KEY",
  // apiKey: "PLATFORM_APP_API_KEY",
});

const updateInboxRequest: api.UpdateInboxRequest = {
  enable_auto_assignment: false,
};

new api.InboxesApi(configuration).updateInbox(
  0, // accountId
  0, // id
  updateInboxRequest, // data
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling InboxesApi#updateInbox:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
