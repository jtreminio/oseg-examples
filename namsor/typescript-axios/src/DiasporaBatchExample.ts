import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const personalNames1: api.FirstLastNameGeoIn = {
  id: "0d7d6417-0bbb-4205-951d-b3473f605b56",
  firstName: "Keith",
  lastName: "Haring",
  countryIso2: "US",
};

const personalNames = [
  personalNames1,
];

const batchFirstLastNameGeoIn: api.BatchFirstLastNameGeoIn = {
  personalNames: personalNames,
};

new api.PersonalApi(configuration).diasporaBatch(
  batchFirstLastNameGeoIn,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling PersonalApi#diasporaBatch:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
