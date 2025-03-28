import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.AccountMembersApi(configuration).deleteMember(
  "id_string", // id
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AccountMembersApi#deleteMember:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
