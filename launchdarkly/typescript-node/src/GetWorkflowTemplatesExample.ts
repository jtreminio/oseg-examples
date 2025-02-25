import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.WorkflowTemplatesApi();
apiCaller.setApiKey(api.WorkflowTemplatesApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getWorkflowTemplates().then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling WorkflowTemplates#getWorkflowTemplates:");
  console.log(error.body);
});
