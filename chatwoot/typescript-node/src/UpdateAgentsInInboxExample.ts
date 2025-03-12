import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.InboxesApi();
apiCaller.setApiKey(api.InboxesApiApiKeys.userApiKey, "USER_API_KEY");

const updateAgentsInInboxRequest = new models.UpdateAgentsInInboxRequest();
updateAgentsInInboxRequest.inboxId = undefined;
updateAgentsInInboxRequest.userIds = [
];

apiCaller.updateAgentsInInbox(
  undefined, // accountId
  updateAgentsInInboxRequest, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling InboxesApi#updateAgentsInInbox:");
  console.log(error.body);
});
