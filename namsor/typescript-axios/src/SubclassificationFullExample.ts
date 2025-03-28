import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.PersonalApi(configuration).subclassificationFull(
  "NG", // countryIso2
  "Jannat Rahmani", // fullName
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling PersonalApi#subclassificationFull:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
