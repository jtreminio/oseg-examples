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
        ApiClient.apiKey["userApiKey"] = "USER_API_KEY"
        // ApiClient.apiKey["agentBotApiKey"] = "AGENT_BOT_API_KEY"

        val contactFilterRequest = ContactFilterRequest(
            payload = Serializer.moshi.adapter<List<Map<String, Any>>>().fromJson("""
                [
                    {
                        "attribute_key": "name",
                        "filter_operator": "equal_to",
                        "query_operator": "AND",
                        "values": [
                            "en"
                        ]
                    },
                    {
                        "attribute_key": "country_code",
                        "filter_operator": "equal_to",
                        "query_operator": null,
                        "values": [
                            "us"
                        ]
                    }
                ]
            """)!!,
        )

        try
        {
            val response = ContactsApi().contactFilter(
                accountId = null,
                body = contactFilterRequest,
                page = null,
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
