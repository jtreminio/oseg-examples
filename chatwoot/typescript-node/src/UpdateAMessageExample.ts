import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.MessagesAPIApi();

const publicMessageUpdatePayload: models.PublicMessageUpdatePayload = {
};

apiCaller.updateAMessage(
  "inbox_identifier_string", // inboxIdentifier
  "contact_identifier_string", // contactIdentifier
  0, // conversationId
  0, // messageId
  publicMessageUpdatePayload, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling MessagesAPIApi#updateAMessage:");
  console.log(error.body);
});
