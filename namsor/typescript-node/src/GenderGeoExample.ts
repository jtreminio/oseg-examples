import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.PersonalApi();
apiCaller.setApiKey(api.PersonalApiApiKeys.api_key, "YOUR_API_KEY");

apiCaller.genderGeo(
  "Keith", // firstName
  "Haring", // lastName
  "US", // countryIso2
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling PersonalApi#genderGeo:");
  console.log(error.body);
});
