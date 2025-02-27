import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.PersonalApi();
apiCaller.setApiKey(api.PersonalApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1 = new models.FirstLastNameGeoZippedIn();
personalNames1.id = "728767f9-c5b2-4ed3-a071-828077f16552";
personalNames1.firstName = "Keith";
personalNames1.lastName = "Haring";
personalNames1.countryIso2 = "US";
personalNames1.zipCode = "10019";

const personalNames = [
  personalNames1,
];

const batchFirstLastNameGeoZippedIn = new models.BatchFirstLastNameGeoZippedIn();
batchFirstLastNameGeoZippedIn.personalNames = personalNames;

apiCaller.usZipRaceEthnicityBatch(
  batchFirstLastNameGeoZippedIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling PersonalApi#usZipRaceEthnicityBatch:");
  console.log(error.body);
});
