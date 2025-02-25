import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.LayersApi();
apiCaller.setApiKey(api.LayersApiApiKeys.ApiKey, "YOUR_API_KEY");

const layerPatchInput = new models.LayerPatchInput();
layerPatchInput.instructions =   [
  {
    "experimentKey": "checkout-button-color",
    "kind": "updateExperimentReservation",
    "reservationPercent": 25
  }
];
layerPatchInput.comment = "Example comment describing the update";
layerPatchInput.environmentKey = "production";

apiCaller.updateLayer(
  undefined, // projectKey
  undefined, // layerKey
  layerPatchInput,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling Layers#updateLayer:");
  console.log(error.body);
});
