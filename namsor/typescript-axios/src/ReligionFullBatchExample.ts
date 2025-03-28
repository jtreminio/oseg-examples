import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const personalNames1: api.PersonalNameGeoSubdivisionIn = {
  id: "id",
  name: "name",
  countryIso2: "countryIso2",
  subdivisionIso: "subdivisionIso",
};

const personalNames2: api.PersonalNameGeoSubdivisionIn = {
  id: "id",
  name: "name",
  countryIso2: "countryIso2",
  subdivisionIso: "subdivisionIso",
};

const personalNames = [
  personalNames1,
  personalNames2,
];

const batchPersonalNameGeoSubdivisionIn: api.BatchPersonalNameGeoSubdivisionIn = {
  personalNames: personalNames,
};

new api.PersonalApi(configuration).religionFullBatch(
  batchPersonalNameGeoSubdivisionIn,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling PersonalApi#religionFullBatch:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
