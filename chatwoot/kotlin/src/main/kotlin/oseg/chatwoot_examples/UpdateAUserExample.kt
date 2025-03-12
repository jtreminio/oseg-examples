package oseg.chatwoot_examples

import com.chatwoot.client.infrastructure.*
import com.chatwoot.client.apis.*
import com.chatwoot.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class UpdateAUserExample
{
    fun updateAUser()
    {
        ApiClient.apiKey["platformAppApiKey"] = "PLATFORM_APP_API_KEY"

        val userCreateUpdatePayload = UserCreateUpdatePayload(
            name = null,
            email = null,
            password = null,
        )

        try
        {
            val response = UsersApi().updateAUser(
                id = null,
                _data = userCreateUpdatePayload,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling UsersApi#updateAUser")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling UsersApi#updateAUser")
            e.printStackTrace()
        }
    }
}
