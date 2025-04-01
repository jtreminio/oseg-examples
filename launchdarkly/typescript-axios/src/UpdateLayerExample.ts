import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const layerPatchInput: api.LayerPatchInput = {
  instructions: [
    {
      "experimentKey": "checkout-button-color",
      "kind": "updateExperimentReservation",
      "reservationPercent": 25
    }
  ],
  comment: "Example comment describing the update",
  environmentKey: "production",
};

new api.LayersApi(configuration).updateLayer(
  "projectKey_string", // projectKey
  "layerKey_string", // layerKey
  layerPatchInput,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling LayersApi#updateLayer:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
