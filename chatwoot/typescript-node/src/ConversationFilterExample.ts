import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.ConversationsApi();
apiCaller.setApiKey(api.ConversationsApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.ConversationsApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");

const conversationFilterRequest = new models.ConversationFilterRequest();
conversationFilterRequest.payload =   [
  {
    "attribute_key": "browser_language",
    "filter_operator": "not_eq",
    "query_operator": "AND",
    "values": [
      "en"
    ]
  },
  {
    "attribute_key": "status",
    "filter_operator": "eq",
    "query_operator": null,
    "values": [
      "pending"
    ]
  }
];

apiCaller.conversationFilter(
  undefined, // accountId
  conversationFilterRequest, // body
  undefined, // page
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ConversationsApi#conversationFilter:");
  console.log(error.body);
});
