import axios, { AxiosError } from "axios";
import * as api from "namsor_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.ChineseApi(configuration).pinyinChineseName(
  "赵丽颖", // chineseName
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ChineseApi#pinyinChineseName:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
