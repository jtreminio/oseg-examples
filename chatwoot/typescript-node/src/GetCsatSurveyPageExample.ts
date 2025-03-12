import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.CSATSurveyPageApi();

apiCaller.getCsatSurveyPage(
  undefined, // conversationUuid
).catch(error => {
  console.log("Exception when calling CSATSurveyPageApi#getCsatSurveyPage:");
  console.log(error.body);
});
