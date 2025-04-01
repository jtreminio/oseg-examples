import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const personalNames1: api.PersonalNameIn = {
  id: "9a3283bd-4efb-4b7b-906c-e3f3c03ea6a4",
  name: "Keith Haring",
};

const personalNames = [
  personalNames1,
];

const batchPersonalNameIn: api.BatchPersonalNameIn = {
  personalNames: personalNames,
};

new api.PersonalApi(configuration).countryBatch(
  batchPersonalNameIn,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling PersonalApi#countryBatch:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
