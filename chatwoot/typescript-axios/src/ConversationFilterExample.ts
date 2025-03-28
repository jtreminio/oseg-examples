import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
  // apiKey: "AGENT_BOT_API_KEY",
});

const payload1: api.ContactFilterRequestPayloadInner = {
  attribute_key: "browser_language",
  filter_operator: api.ContactFilterRequestPayloadInnerFilterOperatorEnum.NotEqualTo,
  query_operator: api.ContactFilterRequestPayloadInnerQueryOperatorEnum.And,
  values: [
    "en",
  ],
};

const payload2: api.ContactFilterRequestPayloadInner = {
  attribute_key: "status",
  filter_operator: api.ContactFilterRequestPayloadInnerFilterOperatorEnum.EqualTo,
  values: [
    "pending",
  ],
};

const payload = [
  payload1,
  payload2,
];

const conversationFilterRequest: api.ConversationFilterRequest = {
  payload: payload,
};

new api.ConversationsApi(configuration).conversationFilter(
  123, // accountId
  conversationFilterRequest, // body
  1, // page
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ConversationsApi#conversationFilter:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
