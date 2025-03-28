import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const personalNames1: api.PersonalNameGeoIn = {
  id: "85dd5f48-b9e1-4019-88ce-ccc7e56b763f",
  name: "Keith Haring",
  countryIso2: "US",
};

const personalNames = [
  personalNames1,
];

const batchPersonalNameGeoIn: api.BatchPersonalNameGeoIn = {
  personalNames: personalNames,
};

new api.PersonalApi(configuration).usRaceEthnicityFullBatch(
  batchPersonalNameGeoIn,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling PersonalApi#usRaceEthnicityFullBatch:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
