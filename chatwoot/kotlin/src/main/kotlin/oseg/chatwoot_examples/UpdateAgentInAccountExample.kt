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
class UpdateAgentInAccountExample
{
    fun updateAgentInAccount()
    {
        ApiClient.apiKey["api_access_token"] = "USER_API_KEY"

        val updateAgentInAccountRequest = UpdateAgentInAccountRequest(
            role = UpdateAgentInAccountRequest.Role.agent,
        )

        try
        {
            val response = AgentsApi().updateAgentInAccount(
                accountId = 0,
                id = 0,
                _data = updateAgentInAccountRequest,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling AgentsApi#updateAgentInAccount")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling AgentsApi#updateAgentInAccount")
            e.printStackTrace()
        }
    }
}
