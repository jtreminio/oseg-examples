import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.TagsApi();
apiCaller.setApiKey(api.TagsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getTags().then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling Tags#getTags:");
  console.log(error.body);
});
