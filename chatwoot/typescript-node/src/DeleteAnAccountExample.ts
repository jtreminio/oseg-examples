import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.AccountsApi();
apiCaller.setApiKey(api.AccountsApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

apiCaller.deleteAnAccount(
  0, // accountId
).catch(error => {
  console.log("Exception when calling AccountsApi#deleteAnAccount:");
  console.log(error.body);
});
