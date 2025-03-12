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
class ListAllAccountUsersExample
{
    fun listAllAccountUsers()
    {
        ApiClient.apiKey["platformAppApiKey"] = "PLATFORM_APP_API_KEY"

        try
        {
            val response = AccountUsersApi().listAllAccountUsers(
                accountId = null,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling AccountUsersApi#listAllAccountUsers")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling AccountUsersApi#listAllAccountUsers")
            e.printStackTrace()
        }
    }
}
