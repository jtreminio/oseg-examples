import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.InboxesApi();
apiCaller.setApiKey(api.InboxesApiApiKeys.userApiKey, "USER_API_KEY");

apiCaller.getInboxMembers(
  0, // accountId
  0, // inboxId
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling InboxesApi#getInboxMembers:");
  console.log(error.body);
});
