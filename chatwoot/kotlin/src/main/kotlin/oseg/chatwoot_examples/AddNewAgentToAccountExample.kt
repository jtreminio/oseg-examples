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
class AddNewAgentToAccountExample
{
    fun addNewAgentToAccount()
    {
        ApiClient.apiKey["userApiKey"] = "USER_API_KEY"

        val addNewAgentToAccountRequest = AddNewAgentToAccountRequest(
            email = null,
            name = null,
            role = null,
            availabilityStatus = null,
            autoOffline = null,
        )

        try
        {
            val response = AgentsApi().addNewAgentToAccount(
                accountId = null,
                _data = addNewAgentToAccountRequest,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling AgentsApi#addNewAgentToAccount")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling AgentsApi#addNewAgentToAccount")
            e.printStackTrace()
        }
    }
}
