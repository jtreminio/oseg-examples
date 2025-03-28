import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
  // apiKey: "AGENT_BOT_API_KEY",
  // apiKey: "PLATFORM_APP_API_KEY",
});

const integrationsHookUpdatePayload: api.IntegrationsHookUpdatePayload = {
};

new api.IntegrationsApi(configuration).updateAnIntegrationsHook(
  0, // accountId
  0, // hookId
  integrationsHookUpdatePayload, // data
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling IntegrationsApi#updateAnIntegrationsHook:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
