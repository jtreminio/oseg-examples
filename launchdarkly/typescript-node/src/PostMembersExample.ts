import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.AccountMembersApi();
apiCaller.setApiKey(api.AccountMembersApiApiKeys.ApiKey, "YOUR_API_KEY");

const newMemberForm1 = new models.NewMemberForm();
newMemberForm1.email = "sandy@acme.com";
newMemberForm1.password = "***";
newMemberForm1.firstName = "Ariel";
newMemberForm1.lastName = "Flores";
newMemberForm1.role = models.NewMemberForm.RoleEnum.Reader;
newMemberForm1.customRoles = [
  "customRole1",
  "customRole2",
];
newMemberForm1.teamKeys = [
  "team-1",
  "team-2",
];
newMemberForm1.roleAttributes = undefined;

const newMemberForm = [
  newMemberForm1,
];

apiCaller.postMembers(
  newMemberForm,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AccountMembers#postMembers:");
  console.log(error.body);
});
