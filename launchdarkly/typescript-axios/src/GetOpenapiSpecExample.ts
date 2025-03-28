import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.OtherApi(configuration).getOpenapiSpec().catch((error: Error | AxiosError) => {
  console.log("Exception when calling OtherApi#getOpenapiSpec:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
