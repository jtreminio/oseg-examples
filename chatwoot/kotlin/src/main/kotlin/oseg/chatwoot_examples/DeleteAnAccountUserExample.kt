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
class DeleteAnAccountUserExample
{
    fun deleteAnAccountUser()
    {
        ApiClient.apiKey["platformAppApiKey"] = "PLATFORM_APP_API_KEY"

        val deleteAnAccountUserRequest = DeleteAnAccountUserRequest(
            userId = null,
        )

        try
        {
            AccountUsersApi().deleteAnAccountUser(
                accountId = null,
                _data = deleteAnAccountUserRequest,
            )
        } catch (e: ClientException) {
            println("4xx response calling AccountUsersApi#deleteAnAccountUser")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling AccountUsersApi#deleteAnAccountUser")
            e.printStackTrace()
        }
    }
}
