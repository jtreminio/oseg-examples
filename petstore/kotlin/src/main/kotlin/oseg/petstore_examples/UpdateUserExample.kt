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

class UpdateUserExample
{
    fun updateUser()
    {
        ApiClient.apiKey["api_key"] = "YOUR_API_KEY"

        val user = User(
            id = 12345,
            username = "new-username",
            firstName = "Joe",
            lastName = "Broke",
            email = "some-email@example.com",
            password = "so secure omg",
            phone = "555-867-5309",
            userStatus = 1,
        )

        try
        {
            UserApi().updateUser(
                username = "my-username",
                user = user,
            )
        } catch (e: ClientException) {
            println("4xx response calling UserApi#updateUser")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling UserApi#updateUser")
            e.printStackTrace()
        }
    }
}
