import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.ChineseApi();
apiCaller.setApiKey(api.ChineseApiApiKeys.api_key, "YOUR_API_KEY");

apiCaller.pinyinChineseName(
  "赵丽颖", // chineseName
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ChineseApi#pinyinChineseName:");
  console.log(error.body);
});
