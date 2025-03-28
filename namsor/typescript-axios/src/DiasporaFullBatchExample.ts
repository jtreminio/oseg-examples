import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const personalNames1: api.PersonalNameGeoIn = {
  id: "0d7d6417-0bbb-4205-951d-b3473f605b56",
  name: "Keith Haring",
  countryIso2: "US",
};

const personalNames = [
  personalNames1,
];

const batchPersonalNameGeoIn: api.BatchPersonalNameGeoIn = {
  personalNames: personalNames,
};

new api.PersonalApi(configuration).diasporaFullBatch(
  batchPersonalNameGeoIn,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling PersonalApi#diasporaFullBatch:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
