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
class CreateAMessageExample
{
    fun createAMessage()
    {

        val publicMessageCreatePayload = PublicMessageCreatePayload(
            content = null,
            echoId = null,
        )

        try
        {
            val response = MessagesAPIApi().createAMessage(
                inboxIdentifier = null,
                contactIdentifier = null,
                conversationId = null,
                _data = publicMessageCreatePayload,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling MessagesAPIApi#createAMessage")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling MessagesAPIApi#createAMessage")
            e.printStackTrace()
        }
    }
}
