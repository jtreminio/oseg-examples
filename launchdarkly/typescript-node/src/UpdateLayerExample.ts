import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.LayersApi();
apiCaller.setApiKey(api.LayersApiApiKeys.ApiKey, "YOUR_API_KEY");

const layerPatchInput: models.LayerPatchInput = {
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

apiCaller.updateLayer(
  "projectKey_string", // projectKey
  "layerKey_string", // layerKey
  layerPatchInput,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling LayersApi#updateLayer:");
  console.log(error.body);
});
