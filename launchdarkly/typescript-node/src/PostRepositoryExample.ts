import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.CodeReferencesApi();
apiCaller.setApiKey(api.CodeReferencesApiApiKeys.ApiKey, "YOUR_API_KEY");

const repositoryPost = new models.RepositoryPost();
repositoryPost.name = "LaunchDarkly-Docs";
repositoryPost.sourceLink = "https://github.com/launchdarkly/LaunchDarkly-Docs";
repositoryPost.commitUrlTemplate = "https://github.com/launchdarkly/LaunchDarkly-Docs/commit/${sha}";
repositoryPost.hunkUrlTemplate = "https://github.com/launchdarkly/LaunchDarkly-Docs/blob/${sha}/${filePath}#L${lineNumber}";
repositoryPost.type = models.RepositoryPost.TypeEnum.Github;
repositoryPost.defaultBranch = "main";

apiCaller.postRepository(
  repositoryPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling CodeReferencesApi#postRepository:");
  console.log(error.body);
});
