import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.AccountUsersApi();
apiCaller.setApiKey(api.AccountUsersApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

apiCaller.listAllAccountUsers(
  undefined, // accountId
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AccountUsersApi#listAllAccountUsers:");
  console.log(error.body);
});
