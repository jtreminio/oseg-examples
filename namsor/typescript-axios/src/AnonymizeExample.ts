import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.AdminApi(configuration).anonymize(
  "source", // source
  true, // anonymized
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AdminApi#anonymize:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
