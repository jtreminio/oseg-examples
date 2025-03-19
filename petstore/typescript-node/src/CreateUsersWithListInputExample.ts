import * as fs from 'fs';
import api from "openapi_client"
import models from "openapi_client"

const apiCaller = new api.UserApi();
apiCaller.setApiKey(api.UserApiApiKeys.api_key, "YOUR_API_KEY");

const user1: models.User = {
  id: 12345,
  username: "my_user_1",
  firstName: "John",
  lastName: "Doe",
  email: "john@example.com",
  password: "secure_123",
  phone: "555-123-1234",
  userStatus: 1,
};

const user2: models.User = {
  id: 67890,
  username: "my_user_2",
  firstName: "Jane",
  lastName: "Doe",
  email: "jane@example.com",
  password: "secure_456",
  phone: "555-123-5678",
  userStatus: 2,
};

const user = [
  user1,
  user2,
];

apiCaller.createUsersWithListInput(
  user,
).catch(error => {
  console.log("Exception when calling UserApi#createUsersWithListInput:");
  console.log(error.body);
});
