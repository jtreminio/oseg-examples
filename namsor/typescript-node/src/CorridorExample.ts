import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.PersonalApi();
apiCaller.setApiKey(api.PersonalApiApiKeys.api_key, "YOUR_API_KEY");

apiCaller.corridor(
  "GB", // countryIso2From
  "Ada", // firstNameFrom
  "Lovelace", // lastNameFrom
  "US", // countryIso2To
  "Nicolas", // firstNameTo
  "Tesla", // lastNameTo
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling PersonalApi#corridor:");
  console.log(error.body);
});
