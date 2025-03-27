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
class ConversationFilterExample
{
    fun conversationFilter()
    {
        ApiClient.apiKey["api_access_token"] = "USER_API_KEY"
        // ApiClient.apiKey["api_access_token"] = "AGENT_BOT_API_KEY"

        val payload1 = ContactFilterRequestPayloadInner(
            attributeKey = "browser_language",
            filterOperator = ContactFilterRequestPayloadInner.FilterOperator.notEqualTo,
            queryOperator = ContactFilterRequestPayloadInner.QueryOperator.aND,
            values = listOf (
                "en",
            ),
        )

        val payload2 = ContactFilterRequestPayloadInner(
            attributeKey = "status",
            filterOperator = ContactFilterRequestPayloadInner.FilterOperator.equalTo,
            values = listOf (
                "pending",
            ),
        )

        val payload = arrayListOf<ContactFilterRequestPayloadInner>(
            payload1,
            payload2,
        )

        val conversationFilterRequest = ConversationFilterRequest(
            payload = payload,
        )

        try
        {
            val response = ConversationsApi().conversationFilter(
                accountId = 123,
                body = conversationFilterRequest,
                page = 1,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ConversationsApi#conversationFilter")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ConversationsApi#conversationFilter")
            e.printStackTrace()
        }
    }
}
