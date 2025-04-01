import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const personalNames1: api.FirstLastNameGeoSubdivisionIn = {
  id: "id",
  firstName: "firstName",
  lastName: "lastName",
  countryIso2: "countryIso2",
  subdivisionIso: "subdivisionIso",
};

const personalNames2: api.FirstLastNameGeoSubdivisionIn = {
  id: "id",
  firstName: "firstName",
  lastName: "lastName",
  countryIso2: "countryIso2",
  subdivisionIso: "subdivisionIso",
};

const personalNames = [
  personalNames1,
  personalNames2,
];

const batchFirstLastNameGeoSubdivisionIn: api.BatchFirstLastNameGeoSubdivisionIn = {
  personalNames: personalNames,
};

new api.IndianApi(configuration).casteIndianBatch(
  batchFirstLastNameGeoSubdivisionIn,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling IndianApi#casteIndianBatch:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
