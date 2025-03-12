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
class ContactUpdateExample
{
    fun contactUpdate()
    {
        ApiClient.apiKey["userApiKey"] = "USER_API_KEY"
        // ApiClient.apiKey["agentBotApiKey"] = "AGENT_BOT_API_KEY"
        // ApiClient.apiKey["platformAppApiKey"] = "PLATFORM_APP_API_KEY"

        val contactUpdate = ContactUpdate(
            name = null,
            email = null,
            phoneNumber = null,
            avatarUrl = null,
            identifier = null,
            avatar = null,
        )

        try
        {
            val response = ContactsApi().contactUpdate(
                accountId = null,
                id = null,
                _data = contactUpdate,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ContactsApi#contactUpdate")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ContactsApi#contactUpdate")
            e.printStackTrace()
        }
    }
}
