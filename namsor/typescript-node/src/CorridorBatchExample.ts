import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.PersonalApi();
apiCaller.setApiKey(api.PersonalApiApiKeys.api_key, "YOUR_API_KEY");

const corridorFromTo1FirstLastNameGeoFrom = new models.FirstLastNameGeoIn();
corridorFromTo1FirstLastNameGeoFrom.id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42";
corridorFromTo1FirstLastNameGeoFrom.firstName = "Ada";
corridorFromTo1FirstLastNameGeoFrom.lastName = "Lovelace";
corridorFromTo1FirstLastNameGeoFrom.countryIso2 = "GB";

const corridorFromTo1FirstLastNameGeoTo = new models.FirstLastNameGeoIn();
corridorFromTo1FirstLastNameGeoTo.id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42";
corridorFromTo1FirstLastNameGeoTo.firstName = "Nicolas";
corridorFromTo1FirstLastNameGeoTo.lastName = "Tesla";
corridorFromTo1FirstLastNameGeoTo.countryIso2 = "US";

const corridorFromTo1 = new models.CorridorIn();
corridorFromTo1.id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42";
corridorFromTo1.firstLastNameGeoFrom = corridorFromTo1FirstLastNameGeoFrom;
corridorFromTo1.firstLastNameGeoTo = corridorFromTo1FirstLastNameGeoTo;

const corridorFromTo = [
  corridorFromTo1,
];

const batchCorridorIn = new models.BatchCorridorIn();
batchCorridorIn.corridorFromTo = corridorFromTo;

apiCaller.corridorBatch(
  batchCorridorIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling PersonalApi#corridorBatch:");
  console.log(error.body);
});
