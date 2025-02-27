import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.SocialApi();
apiCaller.setApiKey(api.SocialApiApiKeys.api_key, "YOUR_API_KEY");

apiCaller.phoneCodeGeoFeedbackLoop(
  "Teniola", // firstName
  "Apata", // lastName
  "08186472651", // phoneNumber
  "", // phoneNumberE164
  "NG", // countryIso2
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling SocialApi#phoneCodeGeoFeedbackLoop:");
  console.log(error.body);
});
