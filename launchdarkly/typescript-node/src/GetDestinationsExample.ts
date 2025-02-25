import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.DataExportDestinationsApi();
apiCaller.setApiKey(api.DataExportDestinationsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getDestinations().then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling DataExportDestinations#getDestinations:");
  console.log(error.body);
});
