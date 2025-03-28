import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
});

const automationRuleCreateUpdatePayload: api.AutomationRuleCreateUpdatePayload = {
  name: "Add label on message create event",
  description: "Add label support and sales on message create event if incoming message content contains text help",
  event_name: api.AutomationRuleCreateUpdatePayloadEventNameEnum.MessageCreated,
  actions: [
    {
      "action_name": "add_label",
      "action_params": [
        "support"
      ]
    }
  ],
  conditions: [
    {
      "attribute_key": "content",
      "filter_operator": "contains",
      "query_operator": "nil",
      "values": [
        "help"
      ]
    }
  ],
};

new api.AutomationRuleApi(configuration).updateAutomationRuleInAccount(
  0, // accountId
  0, // id
  automationRuleCreateUpdatePayload, // data
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AutomationRuleApi#updateAutomationRuleInAccount:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
