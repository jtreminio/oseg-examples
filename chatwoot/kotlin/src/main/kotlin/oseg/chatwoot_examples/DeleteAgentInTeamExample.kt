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
class DeleteAgentInTeamExample
{
    fun deleteAgentInTeam()
    {
        ApiClient.apiKey["userApiKey"] = "USER_API_KEY"

        val deleteAgentInTeamRequest = DeleteAgentInTeamRequest(
            userIds = listOf (),
        )

        try
        {
            TeamsApi().deleteAgentInTeam(
                accountId = null,
                teamId = null,
                _data = deleteAgentInTeamRequest,
            )
        } catch (e: ClientException) {
            println("4xx response calling TeamsApi#deleteAgentInTeam")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling TeamsApi#deleteAgentInTeam")
            e.printStackTrace()
        }
    }
}
