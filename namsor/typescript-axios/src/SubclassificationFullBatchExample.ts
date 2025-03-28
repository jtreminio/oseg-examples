import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const personalNames1: api.PersonalNameGeoIn = {
  id: "id",
  name: "name",
  countryIso2: "countryIso2",
};

const personalNames2: api.PersonalNameGeoIn = {
  id: "id",
  name: "name",
  countryIso2: "countryIso2",
};

const personalNames = [
  personalNames1,
  personalNames2,
];

const batchPersonalNameGeoIn: api.BatchPersonalNameGeoIn = {
  personalNames: personalNames,
};

new api.PersonalApi(configuration).subclassificationFullBatch(
  batchPersonalNameGeoIn,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling PersonalApi#subclassificationFullBatch:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
