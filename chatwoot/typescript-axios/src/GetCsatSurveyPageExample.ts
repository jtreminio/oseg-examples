import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
});

new api.CSATSurveyPageApi(configuration).getCsatSurveyPage(
  0, // conversationUuid
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling CSATSurveyPageApi#getCsatSurveyPage:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
