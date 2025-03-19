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
class UpdateConversationExample
{
    fun updateConversation()
    {
        ApiClient.apiKey["api_access_token"] = "USER_API_KEY"
        // ApiClient.apiKey["api_access_token"] = "AGENT_BOT_API_KEY"

        val updateConversationRequest = UpdateConversationRequest()

        try
        {
            ConversationsApi().updateConversation(
                accountId = 0,
                conversationId = 0,
                _data = updateConversationRequest,
            )
        } catch (e: ClientException) {
            println("4xx response calling ConversationsApi#updateConversation")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ConversationsApi#updateConversation")
            e.printStackTrace()
        }
    }
}
