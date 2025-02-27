import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.PersonalApi();
apiCaller.setApiKey(api.PersonalApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1 = new models.PersonalNameGeoIn();
personalNames1.id = "id";
personalNames1.name = "name";
personalNames1.countryIso2 = "countryIso2";

const personalNames2 = new models.PersonalNameGeoIn();
personalNames2.id = "id";
personalNames2.name = "name";
personalNames2.countryIso2 = "countryIso2";

const personalNames = [
  personalNames1,
  personalNames2,
];

const batchPersonalNameGeoIn = new models.BatchPersonalNameGeoIn();
batchPersonalNameGeoIn.personalNames = personalNames;

apiCaller.subclassificationFullBatch(
  batchPersonalNameGeoIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling PersonalApi#subclassificationFullBatch:");
  console.log(error.body);
});
