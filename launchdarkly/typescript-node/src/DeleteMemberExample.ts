import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.AccountMembersApi();
apiCaller.setApiKey(api.AccountMembersApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteMember(
  undefined, // id
).catch(error => {
  console.log("Exception when calling AccountMembers#deleteMember:");
  console.log(error.body);
});
