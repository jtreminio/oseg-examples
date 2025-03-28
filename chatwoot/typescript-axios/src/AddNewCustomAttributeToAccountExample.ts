import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
});

const customAttributeCreateUpdatePayload: api.CustomAttributeCreateUpdatePayload = {
  attribute_values: [
  ],
};

new api.CustomAttributesApi(configuration).addNewCustomAttributeToAccount(
  0, // accountId
  customAttributeCreateUpdatePayload, // data
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling CustomAttributesApi#addNewCustomAttributeToAccount:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
