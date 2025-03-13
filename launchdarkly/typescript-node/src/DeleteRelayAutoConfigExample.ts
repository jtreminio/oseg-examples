import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.RelayProxyConfigurationsApi();
apiCaller.setApiKey(api.RelayProxyConfigurationsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteRelayAutoConfig(
  "id_string", // id
).catch(error => {
  console.log("Exception when calling RelayProxyConfigurationsApi#deleteRelayAutoConfig:");
  console.log(error.body);
});
