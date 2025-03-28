import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.SocialApi(configuration).phoneCodeGeoFeedbackLoop(
  "Teniola", // firstName
  "Apata", // lastName
  "08186472651", // phoneNumber
  "", // phoneNumberE164
  "NG", // countryIso2
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling SocialApi#phoneCodeGeoFeedbackLoop:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
