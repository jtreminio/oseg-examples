import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.PersonalApi();
apiCaller.setApiKey(api.PersonalApiApiKeys.api_key, "YOUR_API_KEY");

apiCaller.usRaceEthnicityZIP5(
  "Keith", // firstName
  "Haring", // lastName
  "12345", // zip5Code
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling PersonalApi#usRaceEthnicityZIP5:");
  console.log(error.body);
});
