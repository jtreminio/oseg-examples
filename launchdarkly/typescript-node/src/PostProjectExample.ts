import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ProjectsApi();
apiCaller.setApiKey(api.ProjectsApiApiKeys.ApiKey, "YOUR_API_KEY");

const projectPost = new models.ProjectPost();
projectPost.name = "My Project";
projectPost.key = "project-key-123abc";

apiCaller.postProject(
  projectPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling Projects#postProject:");
  console.log(error.body);
});
