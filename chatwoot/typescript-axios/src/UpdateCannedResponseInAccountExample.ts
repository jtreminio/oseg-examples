import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
});

const cannedResponseCreateUpdatePayload: api.CannedResponseCreateUpdatePayload = {
};

new api.CannedResponseApi(configuration).updateCannedResponseInAccount(
  0, // accountId
  0, // id
  cannedResponseCreateUpdatePayload, // data
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling CannedResponseApi#updateCannedResponseInAccount:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
