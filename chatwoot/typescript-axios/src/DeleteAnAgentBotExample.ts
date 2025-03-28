import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "PLATFORM_APP_API_KEY",
});

new api.AgentBotsApi(configuration).deleteAnAgentBot(
  0, // id
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AgentBotsApi#deleteAnAgentBot:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
