import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.ChineseApi(configuration).parseChineseName(
  "赵丽颖", // chineseName
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ChineseApi#parseChineseName:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
