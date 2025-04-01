import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.SocialApi(configuration).phoneCode(
  "Jamini", // firstName
  "Roy", // lastName
  "09804201420", // phoneNumber
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling SocialApi#phoneCode:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
