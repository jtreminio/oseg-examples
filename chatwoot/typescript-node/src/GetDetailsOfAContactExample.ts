import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.ContactsAPIApi();

apiCaller.getDetailsOfAContact(
  undefined, // inboxIdentifier
  undefined, // contactIdentifier
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ContactsAPIApi#getDetailsOfAContact:");
  console.log(error.body);
});
