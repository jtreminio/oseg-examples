import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
});

new api.CannedResponsesApi(configuration).deleteCannedResponseFromAccount(
  0, // accountId
  0, // id
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling CannedResponsesApi#deleteCannedResponseFromAccount:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
