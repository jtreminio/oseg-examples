import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.AIConfigsBetaApi();
apiCaller.setApiKey(api.AIConfigsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const modelConfigPost = new models.ModelConfigPost();
modelConfigPost.id = "id";
modelConfigPost.key = "key";
modelConfigPost.name = "name";
modelConfigPost.icon = "icon";
modelConfigPost.provider = "provider";
modelConfigPost.tags = [
  "tags",
  "tags",
];

apiCaller.postModelConfig(
  undefined, // lDAPIVersion
  "default", // projectKey
  modelConfigPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AIConfigsBetaApi#postModelConfig:");
  console.log(error.body);
});
