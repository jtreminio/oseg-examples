import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.AIConfigsBetaApi();
apiCaller.setApiKey(api.AIConfigsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const messages1 = new models.Message();
messages1.content = "content";
messages1.role = "role";

const messages2 = new models.Message();
messages2.content = "content";
messages2.role = "role";

const messages = [
  messages1,
  messages2,
];

const aIConfigVariationPatch = new models.AIConfigVariationPatch();
aIConfigVariationPatch.modelConfigKey = "modelConfigKey";
aIConfigVariationPatch.name = "name";
aIConfigVariationPatch.published = true;
aIConfigVariationPatch.messages = messages;

apiCaller.patchAIConfigVariation(
  undefined, // lDAPIVersion
  undefined, // projectKey
  undefined, // configKey
  undefined, // variationKey
  aIConfigVariationPatch,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AIConfigsBetaApi#patchAIConfigVariation:");
  console.log(error.body);
});
