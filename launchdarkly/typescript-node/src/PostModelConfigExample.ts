import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.AIConfigsBetaApi();
apiCaller.setApiKey(api.AIConfigsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const modelConfigPost: models.ModelConfigPost = {
  id: "id",
  key: "key",
  name: "name",
  icon: "icon",
  provider: "provider",
  tags: [
    "tags",
    "tags",
  ],
  params: {},
  customParams: {},
};

apiCaller.postModelConfig(
  models.ModelConfigPost.LDAPIVersionEnum.Beta, // lDAPIVersion
  "default", // projectKey
  modelConfigPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AIConfigsBetaApi#postModelConfig:");
  console.log(error.body);
});
