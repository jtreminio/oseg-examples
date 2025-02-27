import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.PersonalApi();
apiCaller.setApiKey(api.PersonalApiApiKeys.api_key, "YOUR_API_KEY");

apiCaller.subclassificationFull(
  "NG", // countryIso2
  "Jannat Rahmani", // fullName
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling PersonalApi#subclassificationFull:");
  console.log(error.body);
});
