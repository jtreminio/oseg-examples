import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const personalNames1: api.PersonalNameIn = {
  id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
  name: "中松 義郎",
};

const personalNames = [
  personalNames1,
];

const batchPersonalNameIn: api.BatchPersonalNameIn = {
  personalNames: personalNames,
};

new api.JapaneseApi(configuration).genderJapaneseNameFullBatch(
  batchPersonalNameIn,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling JapaneseApi#genderJapaneseNameFullBatch:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
