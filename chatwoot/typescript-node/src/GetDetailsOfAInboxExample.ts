import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.InboxAPIApi();

apiCaller.getDetailsOfAInbox(
  "inbox_identifier_string", // inboxIdentifier
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling InboxAPIApi#getDetailsOfAInbox:");
  console.log(error.body);
});
