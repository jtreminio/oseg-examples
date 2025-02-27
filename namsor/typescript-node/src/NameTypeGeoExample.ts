import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.GeneralApi();
apiCaller.setApiKey(api.GeneralApiApiKeys.api_key, "YOUR_API_KEY");

apiCaller.nameTypeGeo(
  "Edi Gathegi", // properNoun
  "KE", // countryIso2
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling GeneralApi#nameTypeGeo:");
  console.log(error.body);
});
