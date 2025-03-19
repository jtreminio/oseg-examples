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
class CreateAUserExample
{
    fun createAUser()
    {
        ApiClient.apiKey["api_access_token"] = "PLATFORM_APP_API_KEY"

        val userCreateUpdatePayload = UserCreateUpdatePayload()

        try
        {
            val response = UsersApi().createAUser(
                _data = userCreateUpdatePayload,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling UsersApi#createAUser")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling UsersApi#createAUser")
            e.printStackTrace()
        }
    }
}
