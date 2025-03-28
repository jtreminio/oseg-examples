import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
  // apiKey: "AGENT_BOT_API_KEY",
  // apiKey: "PLATFORM_APP_API_KEY",
});

const contactUpdate: api.ContactUpdate = {
};

new api.ContactsApi(configuration).contactUpdate(
  0, // accountId
  0, // id
  contactUpdate, // data
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ContactsApi#contactUpdate:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
