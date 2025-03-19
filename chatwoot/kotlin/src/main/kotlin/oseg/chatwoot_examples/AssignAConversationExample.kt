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
class AssignAConversationExample
{
    fun assignAConversation()
    {
        ApiClient.apiKey["api_access_token"] = "USER_API_KEY"
        // ApiClient.apiKey["api_access_token"] = "AGENT_BOT_API_KEY"

        val assignAConversationRequest = AssignAConversationRequest()

        try
        {
            val response = ConversationAssignmentApi().assignAConversation(
                accountId = 0,
                conversationId = 0,
                _data = assignAConversationRequest,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ConversationAssignmentApi#assignAConversation")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ConversationAssignmentApi#assignAConversation")
            e.printStackTrace()
        }
    }
}
