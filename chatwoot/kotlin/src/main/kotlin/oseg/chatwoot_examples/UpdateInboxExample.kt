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
class UpdateInboxExample
{
    fun updateInbox()
    {
        ApiClient.apiKey["api_access_token"] = "USER_API_KEY"
        // ApiClient.apiKey["api_access_token"] = "AGENT_BOT_API_KEY"
        // ApiClient.apiKey["api_access_token"] = "PLATFORM_APP_API_KEY"

        val updateInboxRequest = UpdateInboxRequest(
            enableAutoAssignment = false,
        )

        try
        {
            val response = InboxesApi().updateInbox(
                accountId = 0,
                id = 0,
                _data = updateInboxRequest,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling InboxesApi#updateInbox")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling InboxesApi#updateInbox")
            e.printStackTrace()
        }
    }
}
