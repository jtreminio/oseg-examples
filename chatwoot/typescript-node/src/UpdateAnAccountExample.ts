import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.AccountsApi();
apiCaller.setApiKey(api.AccountsApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

const accountCreateUpdatePayload = new models.AccountCreateUpdatePayload();
accountCreateUpdatePayload.name = undefined;

apiCaller.updateAnAccount(
  undefined, // accountId
  accountCreateUpdatePayload, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AccountsApi#updateAnAccount:");
  console.log(error.body);
});
