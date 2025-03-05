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
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class CreateUsersWithListInputExample
{
    fun createUsersWithListInput()
    {
        ApiClient.apiKey["api_key"] = "YOUR_API_KEY"

        val user1 = User(
            id = 12345,
            username = "my_user_1",
            firstName = "John",
            lastName = "Doe",
            email = "john@example.com",
            password = "secure_123",
            phone = "555-123-1234",
            userStatus = 1,
        )

        val user2 = User(
            id = 67890,
            username = "my_user_2",
            firstName = "Jane",
            lastName = "Doe",
            email = "jane@example.com",
            password = "secure_456",
            phone = "555-123-5678",
            userStatus = 2,
        )

        val user = arrayListOf<User>(
            user1,
            user2,
        )

        try
        {
            UserApi().createUsersWithListInput(
                user = user,
            )
        } catch (e: ClientException) {
            println("4xx response calling UserApi#createUsersWithListInput")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling UserApi#createUsersWithListInput")
            e.printStackTrace()
        }
    }
}
