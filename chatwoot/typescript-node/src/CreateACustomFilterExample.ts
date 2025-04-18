import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.CustomFiltersApi();
apiCaller.setApiKey(api.CustomFiltersApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.CustomFiltersApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");
// apiCaller.setApiKey(api.CustomFiltersApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

const customFilterCreateUpdatePayload: models.CustomFilterCreateUpdatePayload = {
};

apiCaller.createACustomFilter(
  0, // accountId
  customFilterCreateUpdatePayload, // data
  undefined, // filterType
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling CustomFiltersApi#createACustomFilter:");
  console.log(error.body);
});
