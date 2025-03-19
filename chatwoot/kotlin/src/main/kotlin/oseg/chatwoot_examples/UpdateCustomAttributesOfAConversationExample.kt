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
class UpdateCustomAttributesOfAConversationExample
{
    fun updateCustomAttributesOfAConversation()
    {
        ApiClient.apiKey["api_access_token"] = "USER_API_KEY"
        // ApiClient.apiKey["api_access_token"] = "AGENT_BOT_API_KEY"

        val updateCustomAttributesOfAConversationRequest = UpdateCustomAttributesOfAConversationRequest(
            customAttributes = Serializer.moshi.adapter<Map<String, Any>>().fromJson("""
                {
                    "order_id": "12345",
                    "previous_conversation": "67890"
                }
            """)!!,
        )

        try
        {
            val response = ConversationsApi().updateCustomAttributesOfAConversation(
                accountId = 0,
                conversationId = 0,
                _data = updateCustomAttributesOfAConversationRequest,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ConversationsApi#updateCustomAttributesOfAConversation")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ConversationsApi#updateCustomAttributesOfAConversation")
            e.printStackTrace()
        }
    }
}
