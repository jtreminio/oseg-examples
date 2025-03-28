import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
});

new api.CustomAttributesApi(configuration).deleteCustomAttributeFromAccount(
  0, // accountId
  0, // id
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling CustomAttributesApi#deleteCustomAttributeFromAccount:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
