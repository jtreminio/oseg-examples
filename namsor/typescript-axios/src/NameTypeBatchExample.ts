import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const properNouns1: api.NameIn = {
  id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
  name: "Zippo",
};

const properNouns = [
  properNouns1,
];

const batchNameIn: api.BatchNameIn = {
  properNouns: properNouns,
};

new api.GeneralApi(configuration).nameTypeBatch(
  batchNameIn,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling GeneralApi#nameTypeBatch:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
