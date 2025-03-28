import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.PersonalApi(configuration).genderGeo(
  "Keith", // firstName
  "Haring", // lastName
  "US", // countryIso2
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling PersonalApi#genderGeo:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
