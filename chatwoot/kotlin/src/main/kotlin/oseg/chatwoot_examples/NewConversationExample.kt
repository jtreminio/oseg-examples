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
class NewConversationExample
{
    fun newConversation()
    {
        ApiClient.apiKey["api_access_token"] = "USER_API_KEY"
        // ApiClient.apiKey["api_access_token"] = "AGENT_BOT_API_KEY"

        val messageTemplateParams = NewConversationRequestMessageTemplateParams(
            name = "sample_issue_resolution",
            category = "UTILITY",
            language = "en_US",
            processedParams = Serializer.moshi.adapter<Map<String, Any>>().fromJson("""
                {
                    "1": "Chatwoot"
                }
            """)!!,
        )

        val message = NewConversationRequestMessage(
            content = "content_string",
            templateParams = messageTemplateParams,
        )

        val newConversationRequest = NewConversationRequest(
            inboxId = "inbox_id_string",
            sourceId = "source_id_string",
            customAttributes = Serializer.moshi.adapter<Map<String, Any>>().fromJson("""
                {
                    "attribute_key": "attribute_value",
                    "priority_conversation_number": 3
                }
            """)!!,
            message = message,
        )

        try
        {
            val response = ConversationsApi().newConversation(
                accountId = 0,
                _data = newConversationRequest,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ConversationsApi#newConversation")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ConversationsApi#newConversation")
            e.printStackTrace()
        }
    }
}
