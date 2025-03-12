import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.ContactsApi();
apiCaller.setApiKey(api.ContactsApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.ContactsApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");

const contactFilterRequest = new models.ContactFilterRequest();
contactFilterRequest.payload =   [
  {
    "attribute_key": "name",
    "filter_operator": "equal_to",
    "query_operator": "AND",
    "values": [
      "en"
    ]
  },
  {
    "attribute_key": "country_code",
    "filter_operator": "equal_to",
    "query_operator": null,
    "values": [
      "us"
    ]
  }
];

apiCaller.contactFilter(
  undefined, // accountId
  contactFilterRequest, // body
  undefined, // page
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ContactsApi#contactFilter:");
  console.log(error.body);
});
