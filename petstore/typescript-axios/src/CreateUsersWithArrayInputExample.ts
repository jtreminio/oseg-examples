import axios, { AxiosError } from "axios";
import * as api from "openapi_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const user1: api.User = {
  id: 12345,
  username: "my_user_1",
  firstName: "John",
  lastName: "Doe",
  email: "john@example.com",
  password: "secure_123",
  phone: "555-123-1234",
  userStatus: 1,
};

const user2: api.User = {
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

new api.UserApi(configuration).createUsersWithArrayInput(
  user,
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling UserApi#createUsersWithArrayInput:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
