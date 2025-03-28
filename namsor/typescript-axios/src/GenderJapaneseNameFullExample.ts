import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.JapaneseApi(configuration).genderJapaneseNameFull(
  "中松 義郎", // japaneseName
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling JapaneseApi#genderJapaneseNameFull:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
