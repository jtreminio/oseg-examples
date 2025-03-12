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
class CreateAConversationExample
{
    fun createAConversation()
    {

        val publicConversationCreatePayload = PublicConversationCreatePayload()
        )

        try
        {
            val response = ConversationsAPIApi().createAConversation(
                inboxIdentifier = null,
                contactIdentifier = null,
                _data = publicConversationCreatePayload,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ConversationsAPIApi#createAConversation")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ConversationsAPIApi#createAConversation")
            e.printStackTrace()
        }
    }
}
