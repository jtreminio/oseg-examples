import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.CannedResponsesApi();
apiCaller.setApiKey(api.CannedResponsesApiApiKeys.userApiKey, "USER_API_KEY");

apiCaller.getAccountCannedResponse(
  undefined, // accountId
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling CannedResponsesApi#getAccountCannedResponse:");
  console.log(error.body);
});
