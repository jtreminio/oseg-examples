import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const personalNames1Name1: api.FirstLastNameIn = {
  id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
  firstName: "Hong",
  lastName: "Yu",
};

const personalNames1Name2: api.PersonalNameIn = {
  id: "e630dda5-13b3-42c5-8f1d-648aa8a21c43",
  name: "喻红",
};

const personalNames1: api.MatchPersonalFirstLastNameIn = {
  id: "e630dda5-13b3-42c5-8f1d-648aa8a21c41",
  name1: personalNames1Name1,
  name2: personalNames1Name2,
};

const personalNames = [
  personalNames1,
];

const batchMatchPersonalFirstLastNameIn: api.BatchMatchPersonalFirstLastNameIn = {
  personalNames: personalNames,
};

new api.ChineseApi(configuration).chineseNameMatchBatch(
  batchMatchPersonalFirstLastNameIn,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ChineseApi#chineseNameMatchBatch:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
