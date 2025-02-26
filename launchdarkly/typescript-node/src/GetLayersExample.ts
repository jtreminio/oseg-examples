import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.LayersApi();
apiCaller.setApiKey(api.LayersApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getLayers(
  undefined, // projectKey
  undefined, // filter
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling LayersApi#getLayers:");
  console.log(error.body);
});
