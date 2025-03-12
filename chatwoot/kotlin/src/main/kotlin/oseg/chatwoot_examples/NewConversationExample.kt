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
        ApiClient.apiKey["userApiKey"] = "USER_API_KEY"
        // ApiClient.apiKey["agentBotApiKey"] = "AGENT_BOT_API_KEY"

        val messageTemplateParams = NewConversationRequestMessageTemplateParams(
            name = "sample_issue_resolution",
            category = "UTILITY",
            language = "en_US",
        )

        val message = NewConversationRequestMessage(
            content = null,
            templateParams = messageTemplateParams,
        )

        val newConversationRequest = NewConversationRequest(
            inboxId = null,
            sourceId = null,
            contactId = null,
            status = null,
            assigneeId = null,
            teamId = null,
            message = message,
        )

        try
        {
            val response = ConversationsApi().newConversation(
                accountId = null,
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
