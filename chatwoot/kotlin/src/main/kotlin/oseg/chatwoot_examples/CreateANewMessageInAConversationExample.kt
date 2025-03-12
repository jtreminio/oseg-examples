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
class CreateANewMessageInAConversationExample
{
    fun createANewMessageInAConversation()
    {
        ApiClient.apiKey["userApiKey"] = "USER_API_KEY"
        // ApiClient.apiKey["agentBotApiKey"] = "AGENT_BOT_API_KEY"

        val templateParams = ConversationMessageCreateTemplateParams(
            name = "sample_issue_resolution",
            category = "UTILITY",
            language = "en_US",
        )

        val conversationMessageCreate = ConversationMessageCreate(
            content = null,
            messageType = null,
            _private = null,
            contentType = ConversationMessageCreate.ContentType.cards,
            templateParams = templateParams,
        )

        try
        {
            val response = MessagesApi().createANewMessageInAConversation(
                accountId = null,
                conversationId = null,
                _data = conversationMessageCreate,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling MessagesApi#createANewMessageInAConversation")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling MessagesApi#createANewMessageInAConversation")
            e.printStackTrace()
        }
    }
}
