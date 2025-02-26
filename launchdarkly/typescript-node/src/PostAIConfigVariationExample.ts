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

const aIConfigVariationPost = new models.AIConfigVariationPost();
aIConfigVariationPost.key = "key";
aIConfigVariationPost.name = "name";
aIConfigVariationPost.modelConfigKey = "modelConfigKey";
aIConfigVariationPost.messages = messages;

apiCaller.postAIConfigVariation(
  undefined, // lDAPIVersion
  undefined, // projectKey
  undefined, // configKey
  aIConfigVariationPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AIConfigsBetaApi#postAIConfigVariation:");
  console.log(error.body);
});
