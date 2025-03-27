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
class ContactInboxCreationExample
{
    fun contactInboxCreation()
    {
        ApiClient.apiKey["api_access_token"] = "USER_API_KEY"
        // ApiClient.apiKey["api_access_token"] = "AGENT_BOT_API_KEY"
        // ApiClient.apiKey["api_access_token"] = "PLATFORM_APP_API_KEY"

        val contactInboxCreationRequest = ContactInboxCreationRequest(
            inboxId = 0,
        )

        try
        {
            val response = ContactApi().contactInboxCreation(
                accountId = 0,
                id = 0,
                _data = contactInboxCreationRequest,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ContactApi#contactInboxCreation")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ContactApi#contactInboxCreation")
            e.printStackTrace()
        }
    }
}
