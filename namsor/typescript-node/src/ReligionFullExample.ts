import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.PersonalApi();
apiCaller.setApiKey(api.PersonalApiApiKeys.api_key, "YOUR_API_KEY");

apiCaller.religionFull(
  "NG", // countryIso2
  "IN-UP", // subDivisionIso31662
  "Akash Sharma", // personalNameFull
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling PersonalApi#religionFull:");
  console.log(error.body);
});
