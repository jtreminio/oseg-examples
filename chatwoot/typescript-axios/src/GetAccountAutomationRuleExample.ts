import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
});

new api.AutomationRuleApi(configuration).getAccountAutomationRule(
  0, // accountId
  1, // page
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AutomationRuleApi#getAccountAutomationRule:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
