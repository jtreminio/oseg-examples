import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.DataExportDestinationsApi();
apiCaller.setApiKey(api.DataExportDestinationsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getDestination(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "id_string", // id
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling DataExportDestinationsApi#getDestination:");
  console.log(error.body);
});
