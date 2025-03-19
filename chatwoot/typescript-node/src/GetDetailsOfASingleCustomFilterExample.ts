import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.CustomFiltersApi();
apiCaller.setApiKey(api.CustomFiltersApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.CustomFiltersApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");
// apiCaller.setApiKey(api.CustomFiltersApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

apiCaller.getDetailsOfASingleCustomFilter(
  0, // accountId
  0, // customFilterId
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling CustomFiltersApi#getDetailsOfASingleCustomFilter:");
  console.log(error.body);
});
