import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const personalNames1: api.PersonalNameSubdivisionIn = {
  id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
  name: "Akash Sharma",
  subdivisionIso: "IN-PB",
};

const personalNames = [
  personalNames1,
];

const batchPersonalNameSubdivisionIn: api.BatchPersonalNameSubdivisionIn = {
  personalNames: personalNames,
};

new api.IndianApi(configuration).religionIndianFullBatch(
  batchPersonalNameSubdivisionIn,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling IndianApi#religionIndianFullBatch:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
