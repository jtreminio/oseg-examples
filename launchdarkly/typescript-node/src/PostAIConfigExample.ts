import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.AIConfigsBetaApi();
apiCaller.setApiKey(api.AIConfigsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const aIConfigPost = new models.AIConfigPost();
aIConfigPost.key = "key";
aIConfigPost.name = "name";
aIConfigPost.description = "";
aIConfigPost.tags = [
  "tags",
  "tags",
];

apiCaller.postAIConfig(
  undefined, // lDAPIVersion
  undefined, // projectKey
  aIConfigPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AIConfigsBeta#postAIConfig:");
  console.log(error.body);
});
