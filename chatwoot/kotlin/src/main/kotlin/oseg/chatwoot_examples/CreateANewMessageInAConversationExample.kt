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
        ApiClient.apiKey["api_access_token"] = "USER_API_KEY"
        // ApiClient.apiKey["api_access_token"] = "AGENT_BOT_API_KEY"

        val templateParams = ConversationMessageCreateTemplateParams(
            name = "sample_issue_resolution",
            category = "UTILITY",
            language = "en_US",
            processedParams = Serializer.moshi.adapter<Map<String, Any>>().fromJson("""
                {
                    "1": "Chatwoot"
                }
            """)!!,
        )

        val conversationMessageCreate = ConversationMessageCreate(
            content = "content_string",
            contentType = ConversationMessageCreate.ContentType.cards,
            templateParams = templateParams,
        )

        try
        {
            val response = MessagesApi().createANewMessageInAConversation(
                accountId = 0,
                conversationId = 0,
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
