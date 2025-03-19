import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.ConversationsAPIApi();

const publicConversationCreatePayload: models.PublicConversationCreatePayload = {
};

apiCaller.createAConversation(
  "inbox_identifier_string", // inboxIdentifier
  "contact_identifier_string", // contactIdentifier
  publicConversationCreatePayload, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ConversationsAPIApi#createAConversation:");
  console.log(error.body);
});
