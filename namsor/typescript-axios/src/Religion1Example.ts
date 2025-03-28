import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.IndianApi(configuration).religion1(
  "IN-UP", // subDivisionIso31662
  "Akash", // firstName
  "Sharma", // lastName
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling IndianApi#religion1:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
