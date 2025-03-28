import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
  // apiKey: "AGENT_BOT_API_KEY",
  // apiKey: "PLATFORM_APP_API_KEY",
});

new api.AccountAgentBotsApi(configuration).deleteAnAccountAgentBot(
  0, // accountId
  0, // id
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AccountAgentBotsApi#deleteAnAccountAgentBot:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
