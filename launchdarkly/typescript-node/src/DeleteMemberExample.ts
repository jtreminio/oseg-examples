import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.AccountMembersApi();
apiCaller.setApiKey(api.AccountMembersApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteMember(
  "id_string", // id
).catch(error => {
  console.log("Exception when calling AccountMembersApi#deleteMember:");
  console.log(error.body);
});
