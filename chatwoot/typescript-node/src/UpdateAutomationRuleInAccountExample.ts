import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.AutomationRuleApi();
apiCaller.setApiKey(api.AutomationRuleApiApiKeys.userApiKey, "USER_API_KEY");

const automationRuleCreateUpdatePayload: models.AutomationRuleCreateUpdatePayload = {
  name: "Add label on message create event",
  description: "Add label support and sales on message create event if incoming message content contains text help",
  eventName: models.AutomationRuleCreateUpdatePayload.EventNameEnum.MessageCreated,
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

apiCaller.updateAutomationRuleInAccount(
  0, // accountId
  0, // id
  automationRuleCreateUpdatePayload, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AutomationRuleApi#updateAutomationRuleInAccount:");
  console.log(error.body);
});
