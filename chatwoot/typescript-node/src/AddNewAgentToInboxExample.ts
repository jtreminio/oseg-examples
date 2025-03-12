import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.InboxesApi();
apiCaller.setApiKey(api.InboxesApiApiKeys.userApiKey, "USER_API_KEY");

const addNewAgentToInboxRequest = new models.AddNewAgentToInboxRequest();
addNewAgentToInboxRequest.inboxId = undefined;
addNewAgentToInboxRequest.userIds = [
];

apiCaller.addNewAgentToInbox(
  undefined, // accountId
  addNewAgentToInboxRequest, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling InboxesApi#addNewAgentToInbox:");
  console.log(error.body);
});
