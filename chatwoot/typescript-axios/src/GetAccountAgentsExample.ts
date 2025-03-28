import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
});

new api.AgentsApi(configuration).getAccountAgents(
  0, // accountId
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AgentsApi#getAccountAgents:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
