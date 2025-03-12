import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.InboxesApi();
apiCaller.setApiKey(api.InboxesApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.InboxesApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");
// apiCaller.setApiKey(api.InboxesApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

const channel = new models.InboxCreationRequestChannel();
channel.type = undefined;
channel.websiteUrl = undefined;
channel.welcomeTitle = undefined;
channel.welcomeTagline = undefined;
channel.agentAwayMessage = undefined;
channel.widgetColor = undefined;

const inboxCreationRequest = new models.InboxCreationRequest();
inboxCreationRequest.name = undefined;
inboxCreationRequest.avatar = undefined;
inboxCreationRequest.channel = channel;

apiCaller.inboxCreation(
  undefined, // accountId
  inboxCreationRequest, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling InboxesApi#inboxCreation:");
  console.log(error.body);
});
