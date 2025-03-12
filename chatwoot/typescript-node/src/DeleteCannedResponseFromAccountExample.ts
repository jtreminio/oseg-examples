import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.CannedResponsesApi();
apiCaller.setApiKey(api.CannedResponsesApiApiKeys.userApiKey, "USER_API_KEY");

apiCaller.deleteCannedResponseFromAccount(
  undefined, // accountId
  undefined, // id
).catch(error => {
  console.log("Exception when calling CannedResponsesApi#deleteCannedResponseFromAccount:");
  console.log(error.body);
});
