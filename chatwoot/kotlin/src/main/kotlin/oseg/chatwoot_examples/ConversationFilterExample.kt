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

        val conversationFilterRequest = ConversationFilterRequest(
            payload = Serializer.moshi.adapter<List<Map<String, Any>>>().fromJson("""
                [
                    {
                        "attribute_key": "browser_language",
                        "filter_operator": "not_eq",
                        "query_operator": "AND",
                        "values": [
                            "en"
                        ]
                    },
                    {
                        "attribute_key": "status",
                        "filter_operator": "eq",
                        "query_operator": null,
                        "values": [
                            "pending"
                        ]
                    }
                ]
            """)!!,
        )

        try
        {
            val response = ConversationsApi().conversationFilter(
                accountId = 0,
                body = conversationFilterRequest,
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
