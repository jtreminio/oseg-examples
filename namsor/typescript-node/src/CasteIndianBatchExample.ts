import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.IndianApi();
apiCaller.setApiKey(api.IndianApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1 = new models.FirstLastNameGeoSubdivisionIn();
personalNames1.id = "id";
personalNames1.firstName = "firstName";
personalNames1.lastName = "lastName";
personalNames1.countryIso2 = "countryIso2";
personalNames1.subdivisionIso = "subdivisionIso";

const personalNames2 = new models.FirstLastNameGeoSubdivisionIn();
personalNames2.id = "id";
personalNames2.firstName = "firstName";
personalNames2.lastName = "lastName";
personalNames2.countryIso2 = "countryIso2";
personalNames2.subdivisionIso = "subdivisionIso";

const personalNames = [
  personalNames1,
  personalNames2,
];

const batchFirstLastNameGeoSubdivisionIn = new models.BatchFirstLastNameGeoSubdivisionIn();
batchFirstLastNameGeoSubdivisionIn.personalNames = personalNames;

apiCaller.casteIndianBatch(
  batchFirstLastNameGeoSubdivisionIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling IndianApi#casteIndianBatch:");
  console.log(error.body);
});
