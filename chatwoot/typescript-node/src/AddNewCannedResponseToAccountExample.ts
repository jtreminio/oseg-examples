import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.CannedResponsesApi();
apiCaller.setApiKey(api.CannedResponsesApiApiKeys.userApiKey, "USER_API_KEY");

const cannedResponseCreateUpdatePayload = new models.CannedResponseCreateUpdatePayload();
cannedResponseCreateUpdatePayload.content = undefined;
cannedResponseCreateUpdatePayload.shortCode = undefined;

apiCaller.addNewCannedResponseToAccount(
  undefined, // accountId
  cannedResponseCreateUpdatePayload, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling CannedResponsesApi#addNewCannedResponseToAccount:");
  console.log(error.body);
});
