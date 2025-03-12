import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.MessagesAPIApi();

const publicMessageCreatePayload = new models.PublicMessageCreatePayload();
publicMessageCreatePayload.content = undefined;
publicMessageCreatePayload.echoId = undefined;

apiCaller.createAMessage(
  undefined, // inboxIdentifier
  undefined, // contactIdentifier
  undefined, // conversationId
  publicMessageCreatePayload, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling MessagesAPIApi#createAMessage:");
  console.log(error.body);
});
