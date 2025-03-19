import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.LayersApi();
apiCaller.setApiKey(api.LayersApiApiKeys.ApiKey, "YOUR_API_KEY");

const layerPost: models.LayerPost = {
  key: "checkout-flow",
  name: "Checkout Flow",
  description: "description_string",
};

apiCaller.createLayer(
  "projectKey_string", // projectKey
  layerPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling LayersApi#createLayer:");
  console.log(error.body);
});
