import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
});

const deleteAgentInInboxRequest: api.DeleteAgentInInboxRequest = {
  inbox_id: "inbox_id_string",
  user_ids: [
  ],
};

new api.InboxesApi(configuration).deleteAgentInInbox(
  0, // accountId
  deleteAgentInInboxRequest, // data
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling InboxesApi#deleteAgentInInbox:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
