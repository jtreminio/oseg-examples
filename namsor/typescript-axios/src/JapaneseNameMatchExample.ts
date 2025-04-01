import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.JapaneseApi(configuration).japaneseNameMatch(
  "Tessai", // japaneseSurnameLatin
  "Tomioka", // japaneseGivenNameLatin
  "富岡 鉄斎", // japaneseName
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling JapaneseApi#japaneseNameMatch:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
