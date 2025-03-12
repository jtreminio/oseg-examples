import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.MessagesAPIApi();

const publicMessageUpdatePayload = new models.PublicMessageUpdatePayload();

apiCaller.updateAMessage(
  undefined, // inboxIdentifier
  undefined, // contactIdentifier
  undefined, // conversationId
  undefined, // messageId
  publicMessageUpdatePayload, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling MessagesAPIApi#updateAMessage:");
  console.log(error.body);
});
