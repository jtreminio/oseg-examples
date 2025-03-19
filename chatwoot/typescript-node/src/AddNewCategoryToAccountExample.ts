import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.HelpCenterApi();
apiCaller.setApiKey(api.HelpCenterApiApiKeys.userApiKey, "USER_API_KEY");

const categoryCreateUpdatePayload: models.CategoryCreateUpdatePayload = {
  locale: "en/es",
};

apiCaller.addNewCategoryToAccount(
  0, // accountId
  0, // portalId
  categoryCreateUpdatePayload, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling HelpCenterApi#addNewCategoryToAccount:");
  console.log(error.body);
});
