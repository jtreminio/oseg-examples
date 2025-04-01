import axios, { AxiosError } from "axios";
import * as api from "openapi_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.StoreApi(configuration).getInventory().then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling StoreApi#getInventory:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
