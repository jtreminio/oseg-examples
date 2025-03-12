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
        ApiClient.apiKey["userApiKey"] = "USER_API_KEY"
        // ApiClient.apiKey["agentBotApiKey"] = "AGENT_BOT_API_KEY"

        val updateCustomAttributesOfAConversationRequest = UpdateCustomAttributesOfAConversationRequest()
        )

        try
        {
            val response = ConversationsApi().updateCustomAttributesOfAConversation(
                accountId = null,
                conversationId = null,
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
