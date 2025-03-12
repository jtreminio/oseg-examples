import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.AutomationRuleApi();
apiCaller.setApiKey(api.AutomationRuleApiApiKeys.userApiKey, "USER_API_KEY");

const automationRuleCreateUpdatePayload = new models.AutomationRuleCreateUpdatePayload();
automationRuleCreateUpdatePayload.name = "Add label on message create event";
automationRuleCreateUpdatePayload.description = "Add label support and sales on message create event if incoming message content contains text help";
automationRuleCreateUpdatePayload.eventName = models.AutomationRuleCreateUpdatePayload.EventNameEnum.MessageCreated;
automationRuleCreateUpdatePayload.active = undefined;

apiCaller.updateAutomationRuleInAccount(
  undefined, // accountId
  undefined, // id
  automationRuleCreateUpdatePayload, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AutomationRuleApi#updateAutomationRuleInAccount:");
  console.log(error.body);
});
