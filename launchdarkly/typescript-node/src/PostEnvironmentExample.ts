import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.EnvironmentsApi();
apiCaller.setApiKey(api.EnvironmentsApiApiKeys.ApiKey, "YOUR_API_KEY");

const environmentPost: models.EnvironmentPost = {
  name: "My Environment",
  key: "environment-key-123abc",
  color: "DADBEE",
};

apiCaller.postEnvironment(
  "projectKey_string", // projectKey
  environmentPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling EnvironmentsApi#postEnvironment:");
  console.log(error.body);
});
