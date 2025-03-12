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
class UpdateAgentsInInboxExample
{
    fun updateAgentsInInbox()
    {
        ApiClient.apiKey["userApiKey"] = "USER_API_KEY"

        val updateAgentsInInboxRequest = UpdateAgentsInInboxRequest(
            inboxId = null,
            userIds = listOf (),
        )

        try
        {
            val response = InboxesApi().updateAgentsInInbox(
                accountId = null,
                _data = updateAgentsInInboxRequest,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling InboxesApi#updateAgentsInInbox")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling InboxesApi#updateAgentsInInbox")
            e.printStackTrace()
        }
    }
}
