import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.HelpCenterApi();
apiCaller.setApiKey(api.HelpCenterApiApiKeys.userApiKey, "USER_API_KEY");

const categoryCreateUpdatePayload = new models.CategoryCreateUpdatePayload();
categoryCreateUpdatePayload.description = undefined;
categoryCreateUpdatePayload.locale = "en/es";
categoryCreateUpdatePayload.name = undefined;
categoryCreateUpdatePayload.slug = undefined;
categoryCreateUpdatePayload.position = undefined;
categoryCreateUpdatePayload.portalId = undefined;
categoryCreateUpdatePayload.accountId = undefined;
categoryCreateUpdatePayload.associatedCategoryId = undefined;
categoryCreateUpdatePayload.parentCategoryId = undefined;

apiCaller.addNewCategoryToAccount(
  undefined, // accountId
  undefined, // portalId
  categoryCreateUpdatePayload, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling HelpCenterApi#addNewCategoryToAccount:");
  console.log(error.body);
});
