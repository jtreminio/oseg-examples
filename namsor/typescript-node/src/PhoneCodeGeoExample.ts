import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.SocialApi();
apiCaller.setApiKey(api.SocialApiApiKeys.api_key, "YOUR_API_KEY");

apiCaller.phoneCodeGeo(
  "Teniola", // firstName
  "Apata", // lastName
  "08186472651", // phoneNumber
  "NG", // countryIso2
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling SocialApi#phoneCodeGeo:");
  console.log(error.body);
});
