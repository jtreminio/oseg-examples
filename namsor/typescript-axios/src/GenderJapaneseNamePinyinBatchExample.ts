import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const personalNames1: api.FirstLastNameIn = {
  id: "id",
  firstName: "firstName",
  lastName: "lastName",
};

const personalNames2: api.FirstLastNameIn = {
  id: "id",
  firstName: "firstName",
  lastName: "lastName",
};

const personalNames = [
  personalNames1,
  personalNames2,
];

const batchFirstLastNameIn: api.BatchFirstLastNameIn = {
  personalNames: personalNames,
};

new api.JapaneseApi(configuration).genderJapaneseNamePinyinBatch(
  batchFirstLastNameIn,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling JapaneseApi#genderJapaneseNamePinyinBatch:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
