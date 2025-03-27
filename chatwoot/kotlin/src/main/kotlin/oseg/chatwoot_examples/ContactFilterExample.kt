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
class ContactFilterExample
{
    fun contactFilter()
    {
        ApiClient.apiKey["api_access_token"] = "USER_API_KEY"
        // ApiClient.apiKey["api_access_token"] = "AGENT_BOT_API_KEY"

        val payload1 = ContactFilterRequestPayloadInner(
            attributeKey = "name",
            filterOperator = ContactFilterRequestPayloadInner.FilterOperator.equalTo,
            queryOperator = ContactFilterRequestPayloadInner.QueryOperator.aND,
            values = listOf (
                "en",
            ),
        )

        val payload2 = ContactFilterRequestPayloadInner(
            attributeKey = "country_code",
            filterOperator = ContactFilterRequestPayloadInner.FilterOperator.equalTo,
            values = listOf (
                "us",
            ),
        )

        val payload = arrayListOf<ContactFilterRequestPayloadInner>(
            payload1,
            payload2,
        )

        val contactFilterRequest = ContactFilterRequest(
            payload = payload,
        )

        try
        {
            val response = ContactsApi().contactFilter(
                accountId = 0,
                body = contactFilterRequest,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ContactsApi#contactFilter")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ContactsApi#contactFilter")
            e.printStackTrace()
        }
    }
}
