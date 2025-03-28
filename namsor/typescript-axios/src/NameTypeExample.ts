import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.GeneralApi(configuration).nameType(
  "Zippo", // properNoun
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling GeneralApi#nameType:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
