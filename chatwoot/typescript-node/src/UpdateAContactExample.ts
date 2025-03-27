import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.ContactsAPIApi();

const publicContactCreateUpdatePayload: models.PublicContactCreateUpdatePayload = {
};

apiCaller.updateAContact(
  "inbox_identifier_string", // inboxIdentifier
  "contact_identifier_string", // contactIdentifier
  publicContactCreateUpdatePayload, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ContactsAPIApi#updateAContact:");
  console.log(error.body);
});
