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
class UpdateAMessageExample
{
    fun updateAMessage()
    {

        val publicMessageUpdatePayload = PublicMessageUpdatePayload()
        )

        try
        {
            val response = MessagesAPIApi().updateAMessage(
                inboxIdentifier = null,
                contactIdentifier = null,
                conversationId = null,
                messageId = null,
                _data = publicMessageUpdatePayload,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling MessagesAPIApi#updateAMessage")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling MessagesAPIApi#updateAMessage")
            e.printStackTrace()
        }
    }
}
