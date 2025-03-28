import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const personalNames1: api.FirstLastNameGeoIn = {
  id: "id",
  firstName: "firstName",
  lastName: "lastName",
  countryIso2: "countryIso2",
};

const personalNames2: api.FirstLastNameGeoIn = {
  id: "id",
  firstName: "firstName",
  lastName: "lastName",
  countryIso2: "countryIso2",
};

const personalNames = [
  personalNames1,
  personalNames2,
];

const batchFirstLastNameGeoIn: api.BatchFirstLastNameGeoIn = {
  personalNames: personalNames,
};

new api.PersonalApi(configuration).communityEngageBatch(
  batchFirstLastNameGeoIn,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling PersonalApi#communityEngageBatch:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
