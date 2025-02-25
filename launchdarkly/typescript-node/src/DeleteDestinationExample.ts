import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.DataExportDestinationsApi();
apiCaller.setApiKey(api.DataExportDestinationsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteDestination(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // id
).catch(error => {
  console.log("Exception when calling DataExportDestinations#deleteDestination:");
  console.log(error.body);
});
