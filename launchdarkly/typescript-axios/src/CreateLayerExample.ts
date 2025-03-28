import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const layerPost: api.LayerPost = {
  key: "checkout-flow",
  name: "Checkout Flow",
  description: "description_string",
};

new api.LayersApi(configuration).createLayer(
  "projectKey_string", // projectKey
  layerPost,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling LayersApi#createLayer:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
