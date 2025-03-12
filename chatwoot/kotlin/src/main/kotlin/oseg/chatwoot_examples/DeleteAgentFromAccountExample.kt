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
class DeleteAgentFromAccountExample
{
    fun deleteAgentFromAccount()
    {
        ApiClient.apiKey["userApiKey"] = "USER_API_KEY"

        try
        {
            AgentsApi().deleteAgentFromAccount(
                accountId = null,
                id = null,
            )
        } catch (e: ClientException) {
            println("4xx response calling AgentsApi#deleteAgentFromAccount")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling AgentsApi#deleteAgentFromAccount")
            e.printStackTrace()
        }
    }
}
