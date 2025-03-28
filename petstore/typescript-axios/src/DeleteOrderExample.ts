import axios, { AxiosError } from "axios";
import * as api from "openapi_client"

const configuration = new api.Configuration({
  accessToken: "YOUR_ACCESS_TOKEN",
  // apiKey: "YOUR_API_KEY",
});

new api.StoreApi(configuration).deleteOrder(
  "12345", // orderId
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling StoreApi#deleteOrder:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
