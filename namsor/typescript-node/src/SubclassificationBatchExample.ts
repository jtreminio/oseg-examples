import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.PersonalApi();
apiCaller.setApiKey(api.PersonalApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1 = new models.FirstLastNameGeoIn();
personalNames1.id = "id";
personalNames1.firstName = "firstName";
personalNames1.lastName = "lastName";
personalNames1.countryIso2 = "countryIso2";

const personalNames2 = new models.FirstLastNameGeoIn();
personalNames2.id = "id";
personalNames2.firstName = "firstName";
personalNames2.lastName = "lastName";
personalNames2.countryIso2 = "countryIso2";

const personalNames = [
  personalNames1,
  personalNames2,
];

const batchFirstLastNameGeoIn = new models.BatchFirstLastNameGeoIn();
batchFirstLastNameGeoIn.personalNames = personalNames;

apiCaller.subclassificationBatch(
  batchFirstLastNameGeoIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling PersonalApi#subclassificationBatch:");
  console.log(error.body);
});
