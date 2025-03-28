import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const personalNames1: api.FirstLastNameIn = {
  id: "9a3283bd-4efb-4b7b-906c-e3f3c03ea6a4",
  firstName: "Keith",
  lastName: "Haring",
};

const personalNames = [
  personalNames1,
];

const batchFirstLastNameIn: api.BatchFirstLastNameIn = {
  personalNames: personalNames,
};

new api.PersonalApi(configuration).countryFnLnBatch(
  batchFirstLastNameIn,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling PersonalApi#countryFnLnBatch:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
