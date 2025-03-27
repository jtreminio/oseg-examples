import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.ConversationsApi();
apiCaller.setApiKey(api.ConversationsApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.ConversationsApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");

const payload1: models.ContactFilterRequestPayloadInner = {
  attributeKey: "browser_language",
  filterOperator: models.ContactFilterRequestPayloadInner.FilterOperatorEnum.NotEqualTo,
  queryOperator: models.ContactFilterRequestPayloadInner.QueryOperatorEnum.And,
  values: [
    "en",
  ],
};

const payload2: models.ContactFilterRequestPayloadInner = {
  attributeKey: "status",
  filterOperator: models.ContactFilterRequestPayloadInner.FilterOperatorEnum.EqualTo,
  values: [
    "pending",
  ],
};

const payload = [
  payload1,
  payload2,
];

const conversationFilterRequest: models.ConversationFilterRequest = {
  payload: payload,
};

apiCaller.conversationFilter(
  123, // accountId
  conversationFilterRequest, // body
  1, // page
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ConversationsApi#conversationFilter:");
  console.log(error.body);
});
