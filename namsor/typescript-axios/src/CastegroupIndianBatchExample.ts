import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const personalNames1: api.FirstLastNameSubdivisionIn = {
  id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
  firstName: "Akash",
  lastName: "Sharma",
  subdivisionIso: "IN-UP",
};

const personalNames = [
  personalNames1,
];

const batchFirstLastNameSubdivisionIn: api.BatchFirstLastNameSubdivisionIn = {
  personalNames: personalNames,
};

new api.IndianApi(configuration).castegroupIndianBatch(
  batchFirstLastNameSubdivisionIn,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling IndianApi#castegroupIndianBatch:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
