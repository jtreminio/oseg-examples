import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.ContactsAPIApi();

const publicContactCreateUpdatePayload: models.PublicContactCreateUpdatePayload = {
};

apiCaller.createAContact(
  "inbox_identifier_string", // inboxIdentifier
  publicContactCreateUpdatePayload, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ContactsAPIApi#createAContact:");
  console.log(error.body);
});
