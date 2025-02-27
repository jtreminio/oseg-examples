import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.IndianApi();
apiCaller.setApiKey(api.IndianApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1 = new models.FirstLastNameSubdivisionIn();
personalNames1.id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42";
personalNames1.firstName = "Akash";
personalNames1.lastName = "Sharma";
personalNames1.subdivisionIso = "IN-UP";

const personalNames = [
  personalNames1,
];

const batchFirstLastNameSubdivisionIn = new models.BatchFirstLastNameSubdivisionIn();
batchFirstLastNameSubdivisionIn.personalNames = personalNames;

apiCaller.castegroupIndianBatch(
  batchFirstLastNameSubdivisionIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling IndianApi#castegroupIndianBatch:");
  console.log(error.body);
});
