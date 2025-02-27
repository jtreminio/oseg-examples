import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.OtherApi();
apiCaller.setApiKey(api.OtherApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getRoot().then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling OtherApi#getRoot:");
  console.log(error.body);
});
