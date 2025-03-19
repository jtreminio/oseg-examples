import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.CodeReferencesApi();
apiCaller.setApiKey(api.CodeReferencesApiApiKeys.ApiKey, "YOUR_API_KEY");

const extinction1: models.Extinction = {
  revision: "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3",
  message: "Remove flag for launched feature",
  time: 1706701522000,
  flagKey: "enable-feature",
  projKey: "default",
};

const extinction = [
  extinction1,
];

apiCaller.postExtinction(
  "repo_string", // repo
  "branch_string", // branch
  extinction,
).catch(error => {
  console.log("Exception when calling CodeReferencesApi#postExtinction:");
  console.log(error.body);
});
