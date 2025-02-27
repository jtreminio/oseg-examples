import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.AdminApi();
apiCaller.setApiKey(api.AdminApiApiKeys.api_key, "YOUR_API_KEY");

apiCaller.learnable1(
  "source", // source
  true, // learnable
).catch(error => {
  console.log("Exception when calling AdminApi#learnable1:");
  console.log(error.body);
});
