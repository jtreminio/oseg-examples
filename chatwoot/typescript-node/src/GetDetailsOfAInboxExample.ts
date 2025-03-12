import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.InboxAPIApi();

apiCaller.getDetailsOfAInbox(
  undefined, // inboxIdentifier
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling InboxAPIApi#getDetailsOfAInbox:");
  console.log(error.body);
});
