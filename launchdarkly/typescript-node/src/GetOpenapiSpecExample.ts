import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.OtherApi();
apiCaller.setApiKey(api.OtherApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getOpenapiSpec().catch(error => {
  console.log("Exception when calling OtherApi#getOpenapiSpec:");
  console.log(error.body);
});
