import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const personalNames1: api.FirstLastNameGeoZippedIn = {
  id: "728767f9-c5b2-4ed3-a071-828077f16552",
  firstName: "Keith",
  lastName: "Haring",
  countryIso2: "US",
  zipCode: "10019",
};

const personalNames = [
  personalNames1,
];

const batchFirstLastNameGeoZippedIn: api.BatchFirstLastNameGeoZippedIn = {
  personalNames: personalNames,
};

new api.PersonalApi(configuration).usZipRaceEthnicityBatch(
  batchFirstLastNameGeoZippedIn,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling PersonalApi#usZipRaceEthnicityBatch:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
