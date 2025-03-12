import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.CannedResponseApi();
apiCaller.setApiKey(api.CannedResponseApiApiKeys.userApiKey, "USER_API_KEY");

const cannedResponseCreateUpdatePayload = new models.CannedResponseCreateUpdatePayload();
cannedResponseCreateUpdatePayload.content = undefined;
cannedResponseCreateUpdatePayload.shortCode = undefined;

apiCaller.updateCannedResponseInAccount(
  undefined, // accountId
  undefined, // id
  cannedResponseCreateUpdatePayload, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling CannedResponseApi#updateCannedResponseInAccount:");
  console.log(error.body);
});
