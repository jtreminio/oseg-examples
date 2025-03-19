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
class UpdateAgentsInTeamExample
{
    fun updateAgentsInTeam()
    {
        ApiClient.apiKey["api_access_token"] = "USER_API_KEY"

        val updateAgentsInTeamRequest = UpdateAgentsInTeamRequest(
            userIds = listOf (),
        )

        try
        {
            val response = TeamsApi().updateAgentsInTeam(
                accountId = 0,
                teamId = 0,
                _data = updateAgentsInTeamRequest,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling TeamsApi#updateAgentsInTeam")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling TeamsApi#updateAgentsInTeam")
            e.printStackTrace()
        }
    }
}
