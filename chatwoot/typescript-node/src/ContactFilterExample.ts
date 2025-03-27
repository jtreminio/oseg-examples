import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.ContactsApi();
apiCaller.setApiKey(api.ContactsApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.ContactsApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");

const payload1: models.ContactFilterRequestPayloadInner = {
  attributeKey: "name",
  filterOperator: models.ContactFilterRequestPayloadInner.FilterOperatorEnum.EqualTo,
  queryOperator: models.ContactFilterRequestPayloadInner.QueryOperatorEnum.And,
  values: [
    "en",
  ],
};

const payload2: models.ContactFilterRequestPayloadInner = {
  attributeKey: "country_code",
  filterOperator: models.ContactFilterRequestPayloadInner.FilterOperatorEnum.EqualTo,
  values: [
    "us",
  ],
};

const payload = [
  payload1,
  payload2,
];

const contactFilterRequest: models.ContactFilterRequest = {
  payload: payload,
};

apiCaller.contactFilter(
  0, // accountId
  contactFilterRequest, // body
  undefined, // page
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ContactsApi#contactFilter:");
  console.log(error.body);
});
