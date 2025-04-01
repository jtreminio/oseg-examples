import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const personalNames1: api.PersonalNameGeoIn = {
  id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
  name: "Jannat Rahmani",
};

const personalNames = [
  personalNames1,
];

const batchPersonalNameGeoIn: api.BatchPersonalNameGeoIn = {
  personalNames: personalNames,
};

new api.IndianApi(configuration).subclassificationIndianFullBatch(
  batchPersonalNameGeoIn,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling IndianApi#subclassificationIndianFullBatch:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
