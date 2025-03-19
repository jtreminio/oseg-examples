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
class ToggleStatusOfAConversationExample
{
    fun toggleStatusOfAConversation()
    {
        ApiClient.apiKey["api_access_token"] = "USER_API_KEY"
        // ApiClient.apiKey["api_access_token"] = "AGENT_BOT_API_KEY"

        val toggleStatusOfAConversationRequest = ToggleStatusOfAConversationRequest(
            status = ToggleStatusOfAConversationRequest.Status.open,
        )

        try
        {
            val response = ConversationsApi().toggleStatusOfAConversation(
                accountId = 0,
                conversationId = 0,
                _data = toggleStatusOfAConversationRequest,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ConversationsApi#toggleStatusOfAConversation")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ConversationsApi#toggleStatusOfAConversation")
            e.printStackTrace()
        }
    }
}
