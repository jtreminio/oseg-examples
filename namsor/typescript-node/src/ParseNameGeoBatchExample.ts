import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.PersonalApi();
apiCaller.setApiKey(api.PersonalApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1 = new models.PersonalNameGeoIn();
personalNames1.id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42";
personalNames1.name = "Ricardo Darín";
personalNames1.countryIso2 = "AR";

const personalNames = [
  personalNames1,
];

const batchPersonalNameGeoIn = new models.BatchPersonalNameGeoIn();
batchPersonalNameGeoIn.personalNames = personalNames;

apiCaller.parseNameGeoBatch(
  batchPersonalNameGeoIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling PersonalApi#parseNameGeoBatch:");
  console.log(error.body);
});
