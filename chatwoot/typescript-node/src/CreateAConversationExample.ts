import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.ConversationsAPIApi();

const publicConversationCreatePayload = new models.PublicConversationCreatePayload();

apiCaller.createAConversation(
  undefined, // inboxIdentifier
  undefined, // contactIdentifier
  publicConversationCreatePayload, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ConversationsAPIApi#createAConversation:");
  console.log(error.body);
});
