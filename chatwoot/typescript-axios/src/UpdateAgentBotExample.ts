import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
  // apiKey: "AGENT_BOT_API_KEY",
  // apiKey: "PLATFORM_APP_API_KEY",
});

const updateAgentBotRequest: api.UpdateAgentBotRequest = {
  agent_bot: 0,
};

new api.InboxesApi(configuration).updateAgentBot(
  0, // accountId
  0, // id
  updateAgentBotRequest, // data
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling InboxesApi#updateAgentBot:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
