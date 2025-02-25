import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.LayersApi();
apiCaller.setApiKey(api.LayersApiApiKeys.ApiKey, "YOUR_API_KEY");

const layerPost = new models.LayerPost();
layerPost.key = "checkout-flow";
layerPost.name = "Checkout Flow";
layerPost.description = undefined;

apiCaller.createLayer(
  undefined, // projectKey
  layerPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling Layers#createLayer:");
  console.log(error.body);
});
