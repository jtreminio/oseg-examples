import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.PersonalApi();
apiCaller.setApiKey(api.PersonalApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1 = new models.PersonalNameGeoIn();
personalNames1.id = "3a2d203a-a6a4-42f9-acd1-1b5c56c7d39f";
personalNames1.name = "Keith Haring";
personalNames1.countryIso2 = "US";

const personalNames = [
  personalNames1,
];

const batchPersonalNameGeoIn = new models.BatchPersonalNameGeoIn();
batchPersonalNameGeoIn.personalNames = personalNames;

apiCaller.genderFullGeoBatch(
  batchPersonalNameGeoIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling PersonalApi#genderFullGeoBatch:");
  console.log(error.body);
});
