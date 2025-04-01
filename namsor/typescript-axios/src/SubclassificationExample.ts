import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.PersonalApi(configuration).subclassification(
  "NG", // countryIso2
  "Jannat", // firstName
  "Rahmani", // lastName
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling PersonalApi#subclassification:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
