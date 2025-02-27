import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.IndianApi();
apiCaller.setApiKey(api.IndianApiApiKeys.api_key, "YOUR_API_KEY");

apiCaller.subclassificationIndianFull(
  "Jannat Rahmani", // fullName
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling IndianApi#subclassificationIndianFull:");
  console.log(error.body);
});
