import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const personalNames1: api.FirstLastNameGenderIn = {
  id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
  firstName: "LiYing",
  lastName: "Zhao",
  gender: "female",
};

const personalNames = [
  personalNames1,
];

const batchFirstLastNameGenderIn: api.BatchFirstLastNameGenderIn = {
  personalNames: personalNames,
};

new api.ChineseApi(configuration).chineseNameCandidatesGenderBatch(
  batchFirstLastNameGenderIn,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ChineseApi#chineseNameCandidatesGenderBatch:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
