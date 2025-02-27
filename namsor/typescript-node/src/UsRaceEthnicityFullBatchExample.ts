import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.PersonalApi();
apiCaller.setApiKey(api.PersonalApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1 = new models.PersonalNameGeoIn();
personalNames1.id = "85dd5f48-b9e1-4019-88ce-ccc7e56b763f";
personalNames1.name = "Keith Haring";
personalNames1.countryIso2 = "US";

const personalNames = [
  personalNames1,
];

const batchPersonalNameGeoIn = new models.BatchPersonalNameGeoIn();
batchPersonalNameGeoIn.personalNames = personalNames;

apiCaller.usRaceEthnicityFullBatch(
  batchPersonalNameGeoIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling PersonalApi#usRaceEthnicityFullBatch:");
  console.log(error.body);
});
