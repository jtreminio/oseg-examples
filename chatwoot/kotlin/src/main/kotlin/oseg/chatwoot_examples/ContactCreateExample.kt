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
class ContactCreateExample
{
    fun contactCreate()
    {
        ApiClient.apiKey["api_access_token"] = "USER_API_KEY"
        // ApiClient.apiKey["api_access_token"] = "AGENT_BOT_API_KEY"
        // ApiClient.apiKey["api_access_token"] = "PLATFORM_APP_API_KEY"

        val contactCreate = ContactCreate(
            inboxId = 0,
        )

        try
        {
            val response = ContactsApi().contactCreate(
                accountId = 0,
                _data = contactCreate,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ContactsApi#contactCreate")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ContactsApi#contactCreate")
            e.printStackTrace()
        }
    }
}
