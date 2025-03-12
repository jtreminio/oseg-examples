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
class GetDetailsOfAnAccountExample
{
    fun getDetailsOfAnAccount()
    {
        ApiClient.apiKey["platformAppApiKey"] = "PLATFORM_APP_API_KEY"

        try
        {
            val response = AccountsApi().getDetailsOfAnAccount(
                accountId = null,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling AccountsApi#getDetailsOfAnAccount")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling AccountsApi#getDetailsOfAnAccount")
            e.printStackTrace()
        }
    }
}
