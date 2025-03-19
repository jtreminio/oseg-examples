import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.CustomAttributesApi();
apiCaller.setApiKey(api.CustomAttributesApiApiKeys.userApiKey, "USER_API_KEY");

apiCaller.getAccountCustomAttribute(
  0, // accountId
  "0", // attributeModel
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling CustomAttributesApi#getAccountCustomAttribute:");
  console.log(error.body);
});
