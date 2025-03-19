import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.AIConfigsBetaApi();
apiCaller.setApiKey(api.AIConfigsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const aIConfigPost: models.AIConfigPost = {
  key: "key",
  name: "name",
  description: "",
  tags: [
    "tags",
    "tags",
  ],
};

apiCaller.postAIConfig(
  models.AIConfigPost.LDAPIVersionEnum.Beta, // lDAPIVersion
  "projectKey_string", // projectKey
  aIConfigPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AIConfigsBetaApi#postAIConfig:");
  console.log(error.body);
});
