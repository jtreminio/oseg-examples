import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.GeneralApi(configuration).nameTypeGeo(
  "Edi Gathegi", // properNoun
  "KE", // countryIso2
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling GeneralApi#nameTypeGeo:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
