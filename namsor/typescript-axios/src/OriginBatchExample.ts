import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const personalNames1: api.FirstLastNameIn = {
  id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
  firstName: "Keith",
  lastName: "Haring",
};

const personalNames = [
  personalNames1,
];

const batchFirstLastNameIn: api.BatchFirstLastNameIn = {
  personalNames: personalNames,
};

new api.PersonalApi(configuration).originBatch(
  batchFirstLastNameIn,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling PersonalApi#originBatch:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
