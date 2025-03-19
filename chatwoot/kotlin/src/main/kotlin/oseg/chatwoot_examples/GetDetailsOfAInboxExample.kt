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
class GetDetailsOfAInboxExample
{
    fun getDetailsOfAInbox()
    {

        try
        {
            val response = InboxAPIApi().getDetailsOfAInbox(
                inboxIdentifier = "inbox_identifier_string",
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling InboxAPIApi#getDetailsOfAInbox")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling InboxAPIApi#getDetailsOfAInbox")
            e.printStackTrace()
        }
    }
}
