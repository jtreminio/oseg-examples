import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.EnvironmentsApi();
apiCaller.setApiKey(api.EnvironmentsApiApiKeys.ApiKey, "YOUR_API_KEY");

const environmentPost = new models.EnvironmentPost();
environmentPost.name = "My Environment";
environmentPost.key = "environment-key-123abc";
environmentPost.color = "DADBEE";

apiCaller.postEnvironment(
  undefined, // projectKey
  environmentPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling EnvironmentsApi#postEnvironment:");
  console.log(error.body);
});
