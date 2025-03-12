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
class ContactAddLabelsExample
{
    fun contactAddLabels()
    {
        ApiClient.apiKey["userApiKey"] = "USER_API_KEY"
        // ApiClient.apiKey["agentBotApiKey"] = "AGENT_BOT_API_KEY"
        // ApiClient.apiKey["platformAppApiKey"] = "PLATFORM_APP_API_KEY"

        val contactAddLabelsRequest = ContactAddLabelsRequest(
            labels = listOf (),
        )

        try
        {
            val response = ContactLabelsApi().contactAddLabels(
                accountId = null,
                contactIdentifier = null,
                _data = contactAddLabelsRequest,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ContactLabelsApi#contactAddLabels")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ContactLabelsApi#contactAddLabels")
            e.printStackTrace()
        }
    }
}
