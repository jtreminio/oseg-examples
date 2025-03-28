import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const corridorFromTo1FirstLastNameGeoFrom: api.FirstLastNameGeoIn = {
  id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
  firstName: "Ada",
  lastName: "Lovelace",
  countryIso2: "GB",
};

const corridorFromTo1FirstLastNameGeoTo: api.FirstLastNameGeoIn = {
  id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
  firstName: "Nicolas",
  lastName: "Tesla",
  countryIso2: "US",
};

const corridorFromTo1: api.CorridorIn = {
  id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
  firstLastNameGeoFrom: corridorFromTo1FirstLastNameGeoFrom,
  firstLastNameGeoTo: corridorFromTo1FirstLastNameGeoTo,
};

const corridorFromTo = [
  corridorFromTo1,
];

const batchCorridorIn: api.BatchCorridorIn = {
  corridorFromTo: corridorFromTo,
};

new api.PersonalApi(configuration).corridorBatch(
  batchCorridorIn,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling PersonalApi#corridorBatch:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
