import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.ContactsAPIApi();

const publicContactCreateUpdatePayload = new models.PublicContactCreateUpdatePayload();
publicContactCreateUpdatePayload.identifier = undefined;
publicContactCreateUpdatePayload.identifierHash = undefined;
publicContactCreateUpdatePayload.email = undefined;
publicContactCreateUpdatePayload.name = undefined;
publicContactCreateUpdatePayload.phoneNumber = undefined;
publicContactCreateUpdatePayload.avatarUrl = undefined;

apiCaller.updateAContact(
  undefined, // inboxIdentifier
  undefined, // contactIdentifier
  publicContactCreateUpdatePayload, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ContactsAPIApi#updateAContact:");
  console.log(error.body);
});
