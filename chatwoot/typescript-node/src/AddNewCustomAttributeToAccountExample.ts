import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.CustomAttributesApi();
apiCaller.setApiKey(api.CustomAttributesApiApiKeys.userApiKey, "USER_API_KEY");

const customAttributeCreateUpdatePayload = new models.CustomAttributeCreateUpdatePayload();
customAttributeCreateUpdatePayload.attributeDisplayName = undefined;
customAttributeCreateUpdatePayload.attributeDisplayType = undefined;
customAttributeCreateUpdatePayload.attributeDescription = undefined;
customAttributeCreateUpdatePayload.attributeKey = undefined;
customAttributeCreateUpdatePayload.attributeModel = undefined;
customAttributeCreateUpdatePayload.attributeValues = [
];

apiCaller.addNewCustomAttributeToAccount(
  undefined, // accountId
  customAttributeCreateUpdatePayload, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling CustomAttributesApi#addNewCustomAttributeToAccount:");
  console.log(error.body);
});
