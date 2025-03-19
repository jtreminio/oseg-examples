import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.CustomAttributesApi();
apiCaller.setApiKey(api.CustomAttributesApiApiKeys.userApiKey, "USER_API_KEY");

const customAttributeCreateUpdatePayload: models.CustomAttributeCreateUpdatePayload = {
  attributeValues: [
  ],
};

apiCaller.updateCustomAttributeInAccount(
  0, // accountId
  0, // id
  customAttributeCreateUpdatePayload, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling CustomAttributesApi#updateCustomAttributeInAccount:");
  console.log(error.body);
});
