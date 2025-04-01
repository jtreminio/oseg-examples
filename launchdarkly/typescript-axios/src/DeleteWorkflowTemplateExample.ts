import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.WorkflowTemplatesApi(configuration).deleteWorkflowTemplate(
  "templateKey_string", // templateKey
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling WorkflowTemplatesApi#deleteWorkflowTemplate:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
