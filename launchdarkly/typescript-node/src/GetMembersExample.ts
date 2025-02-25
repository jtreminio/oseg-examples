import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.AccountMembersApi();
apiCaller.setApiKey(api.AccountMembersApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getMembers().then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AccountMembers#getMembers:");
  console.log(error.body);
});
