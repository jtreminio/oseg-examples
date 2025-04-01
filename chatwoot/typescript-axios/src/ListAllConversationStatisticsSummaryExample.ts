import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
  // apiKey: "AGENT_BOT_API_KEY",
  // apiKey: "PLATFORM_APP_API_KEY",
});

new api.ReportsApi(configuration).listAllConversationStatisticsSummary(
  0, // accountId
  "account", // type
  undefined, // id
  undefined, // since
  undefined, // until
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ReportsApi#listAllConversationStatisticsSummary:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
