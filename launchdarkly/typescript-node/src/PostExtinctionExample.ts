import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.CodeReferencesApi();
apiCaller.setApiKey(api.CodeReferencesApiApiKeys.ApiKey, "YOUR_API_KEY");

const extinction1 = new models.Extinction();
extinction1.revision = "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3";
extinction1.message = "Remove flag for launched feature";
extinction1.time = 1706701522000;
extinction1.flagKey = "enable-feature";
extinction1.projKey = "default";

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
