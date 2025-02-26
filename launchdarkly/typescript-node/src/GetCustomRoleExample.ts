import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.CustomRolesApi();
apiCaller.setApiKey(api.CustomRolesApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getCustomRole(
  undefined, // customRoleKey
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling CustomRolesApi#getCustomRole:");
  console.log(error.body);
});
