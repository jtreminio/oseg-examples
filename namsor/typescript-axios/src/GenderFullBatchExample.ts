import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const personalNames1: api.PersonalNameIn = {
  id: "0f472330-11a9-49ad-a0f5-bcac90a3f6bf",
  name: "Keith Haring",
};

const personalNames = [
  personalNames1,
];

const batchPersonalNameIn: api.BatchPersonalNameIn = {
  personalNames: personalNames,
};

new api.PersonalApi(configuration).genderFullBatch(
  batchPersonalNameIn,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling PersonalApi#genderFullBatch:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
