import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
});

const addNewAgentToInboxRequest: api.AddNewAgentToInboxRequest = {
  inbox_id: "inbox_id_string",
  user_ids: [
  ],
};

new api.InboxesApi(configuration).addNewAgentToInbox(
  0, // accountId
  addNewAgentToInboxRequest, // data
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling InboxesApi#addNewAgentToInbox:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
