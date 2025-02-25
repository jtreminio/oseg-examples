import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.OtherApi();
apiCaller.setApiKey(api.OtherApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getVersions().then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling Other#getVersions:");
  console.log(error.body);
});
