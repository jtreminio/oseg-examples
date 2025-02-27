import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.ChineseApi();
apiCaller.setApiKey(api.ChineseApiApiKeys.api_key, "YOUR_API_KEY");

apiCaller.genderChineseNamePinyin(
  "Dèng", // chineseSurnameLatin
  "Qīngyún", // chineseGivenNameLatin
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ChineseApi#genderChineseNamePinyin:");
  console.log(error.body);
});
