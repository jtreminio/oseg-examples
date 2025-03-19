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
class UpdateAContactExample
{
    fun updateAContact()
    {

        val publicContactCreateUpdatePayload = PublicContactCreateUpdatePayload()

        try
        {
            val response = ContactsAPIApi().updateAContact(
                inboxIdentifier = "inbox_identifier_string",
                contactIdentifier = "contact_identifier_string",
                _data = publicContactCreateUpdatePayload,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ContactsAPIApi#updateAContact")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ContactsAPIApi#updateAContact")
            e.printStackTrace()
        }
    }
}
