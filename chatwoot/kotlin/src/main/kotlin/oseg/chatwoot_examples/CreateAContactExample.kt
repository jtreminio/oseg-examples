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
class CreateAContactExample
{
    fun createAContact()
    {

        val publicContactCreateUpdatePayload = PublicContactCreateUpdatePayload(
            identifier = null,
            identifierHash = null,
            email = null,
            name = null,
            phoneNumber = null,
            avatarUrl = null,
        )

        try
        {
            val response = ContactsAPIApi().createAContact(
                inboxIdentifier = null,
                _data = publicContactCreateUpdatePayload,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ContactsAPIApi#createAContact")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ContactsAPIApi#createAContact")
            e.printStackTrace()
        }
    }
}
