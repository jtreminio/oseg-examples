import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
  // apiKey: "AGENT_BOT_API_KEY",
  // apiKey: "PLATFORM_APP_API_KEY",
});

const contactInboxCreationRequest: api.ContactInboxCreationRequest = {
  inbox_id: 0,
};

new api.ContactApi(configuration).contactInboxCreation(
  0, // accountId
  0, // id
  contactInboxCreationRequest, // data
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ContactApi#contactInboxCreation:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
