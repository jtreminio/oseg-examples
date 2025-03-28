import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.PersonalApi(configuration).corridor(
  "GB", // countryIso2From
  "Ada", // firstNameFrom
  "Lovelace", // lastNameFrom
  "US", // countryIso2To
  "Nicolas", // firstNameTo
  "Tesla", // lastNameTo
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling PersonalApi#corridor:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
