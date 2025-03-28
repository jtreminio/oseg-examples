import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.JapaneseApi(configuration).japaneseNameLatinCandidates(
  "塩田", // japaneseSurnameKanji
  "千春", // japaneseGivenNameKanji
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling JapaneseApi#japaneseNameLatinCandidates:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
