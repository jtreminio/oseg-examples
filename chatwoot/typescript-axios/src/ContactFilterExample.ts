import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
  // apiKey: "AGENT_BOT_API_KEY",
});

const payload1: api.ContactFilterRequestPayloadInner = {
  attribute_key: "name",
  filter_operator: api.ContactFilterRequestPayloadInnerFilterOperatorEnum.EqualTo,
  query_operator: api.ContactFilterRequestPayloadInnerQueryOperatorEnum.And,
  values: [
    "en",
  ],
};

const payload2: api.ContactFilterRequestPayloadInner = {
  attribute_key: "country_code",
  filter_operator: api.ContactFilterRequestPayloadInnerFilterOperatorEnum.EqualTo,
  values: [
    "us",
  ],
};

const payload = [
  payload1,
  payload2,
];

const contactFilterRequest: api.ContactFilterRequest = {
  payload: payload,
};

new api.ContactsApi(configuration).contactFilter(
  0, // accountId
  contactFilterRequest, // body
  undefined, // page
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ContactsApi#contactFilter:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
