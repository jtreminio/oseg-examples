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
class DeleteAgentInInboxExample
{
    fun deleteAgentInInbox()
    {
        ApiClient.apiKey["userApiKey"] = "USER_API_KEY"

        val deleteAgentInInboxRequest = DeleteAgentInInboxRequest(
            inboxId = null,
            userIds = listOf (),
        )

        try
        {
            InboxesApi().deleteAgentInInbox(
                accountId = null,
                _data = deleteAgentInInboxRequest,
            )
        } catch (e: ClientException) {
            println("4xx response calling InboxesApi#deleteAgentInInbox")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling InboxesApi#deleteAgentInInbox")
            e.printStackTrace()
        }
    }
}
