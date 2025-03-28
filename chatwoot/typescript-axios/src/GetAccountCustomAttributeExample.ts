import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
});

new api.CustomAttributesApi(configuration).getAccountCustomAttribute(
  0, // accountId
  "0", // attributeModel
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling CustomAttributesApi#getAccountCustomAttribute:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
