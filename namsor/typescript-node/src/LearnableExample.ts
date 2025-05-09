import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.AdminApi();
apiCaller.setApiKey(api.AdminApiApiKeys.api_key, "YOUR_API_KEY");

apiCaller.learnable(
  "source", // source
  true, // learnable
  "token", // token
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AdminApi#learnable:");
  console.log(error.body);
});
