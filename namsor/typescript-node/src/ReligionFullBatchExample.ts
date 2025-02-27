import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.PersonalApi();
apiCaller.setApiKey(api.PersonalApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1 = new models.PersonalNameGeoSubdivisionIn();
personalNames1.id = "id";
personalNames1.name = "name";
personalNames1.countryIso2 = "countryIso2";
personalNames1.subdivisionIso = "subdivisionIso";

const personalNames2 = new models.PersonalNameGeoSubdivisionIn();
personalNames2.id = "id";
personalNames2.name = "name";
personalNames2.countryIso2 = "countryIso2";
personalNames2.subdivisionIso = "subdivisionIso";

const personalNames = [
  personalNames1,
  personalNames2,
];

const batchPersonalNameGeoSubdivisionIn = new models.BatchPersonalNameGeoSubdivisionIn();
batchPersonalNameGeoSubdivisionIn.personalNames = personalNames;

apiCaller.religionFullBatch(
  batchPersonalNameGeoSubdivisionIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling PersonalApi#religionFullBatch:");
  console.log(error.body);
});
