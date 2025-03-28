import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const personalNames1: api.FirstLastNameIn = {
  id: "b590b04c-da23-4f2f-a334-aee384ee420a",
  firstName: "Keith",
  lastName: "Haring",
};

const personalNames = [
  personalNames1,
];

const batchFirstLastNameIn: api.BatchFirstLastNameIn = {
  personalNames: personalNames,
};

new api.PersonalApi(configuration).genderBatch(
  batchFirstLastNameIn,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling PersonalApi#genderBatch:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
