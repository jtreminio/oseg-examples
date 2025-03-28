import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.InboxesApi();
apiCaller.setApiKey(api.InboxesApiApiKeys.userApiKey, "USER_API_KEY");

const deleteAgentInInboxRequest: models.DeleteAgentInInboxRequest = {
  inboxId: "inbox_id_string",
  userIds: [
  ],
};

apiCaller.deleteAgentInInbox(
  0, // accountId
  deleteAgentInInboxRequest, // data
).catch(error => {
  console.log("Exception when calling InboxesApi#deleteAgentInInbox:");
  console.log(error.body);
});
