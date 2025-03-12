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
        ApiClient.apiKey["userApiKey"] = "USER_API_KEY"
        // ApiClient.apiKey["agentBotApiKey"] = "AGENT_BOT_API_KEY"
        // ApiClient.apiKey["platformAppApiKey"] = "PLATFORM_APP_API_KEY"

        val channel = UpdateInboxRequestChannel(
            websiteUrl = null,
            welcomeTitle = null,
            welcomeTagline = null,
            agentAwayMessage = null,
            widgetColor = null,
        )

        val updateInboxRequest = UpdateInboxRequest(
            enableAutoAssignment = null,
            name = null,
            avatar = null,
            channel = channel,
        )

        try
        {
            val response = InboxesApi().updateInbox(
                accountId = null,
                id = null,
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
