package oseg.petstore_examples

import org.openapitools.client.infrastructure.*
import org.openapitools.client.apis.*
import org.openapitools.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map

class CreateUserExample
{
    fun createUser()
    {
        ApiClient.apiKey["api_key"] = "YOUR_API_KEY"

        val user = User(
            id = 12345,
            username = "my_user",
            firstName = "John",
            lastName = "Doe",
            email = "john@example.com",
            password = "secure_123",
            phone = "555-123-1234",
            userStatus = 1,
        )

        try
        {
            UserApi().createUser(
                user = user,
            )
        } catch (e: ClientException) {
            println("4xx response calling UserApi#createUser")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling UserApi#createUser")
            e.printStackTrace()
        }
    }
}
