import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.MessagesAPIApi();

const publicMessageCreatePayload: models.PublicMessageCreatePayload = {
};

apiCaller.createAMessage(
  "inbox_identifier_string", // inboxIdentifier
  "contact_identifier_string", // contactIdentifier
  0, // conversationId
  publicMessageCreatePayload, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling MessagesAPIApi#createAMessage:");
  console.log(error.body);
});
