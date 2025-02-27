import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.SocialApi();
apiCaller.setApiKey(api.SocialApiApiKeys.api_key, "YOUR_API_KEY");

apiCaller.phoneCode(
  "Jamini", // firstName
  "Roy", // lastName
  "09804201420", // phoneNumber
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling SocialApi#phoneCode:");
  console.log(error.body);
});
