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
class CreateATeamExample
{
    fun createATeam()
    {
        ApiClient.apiKey["api_access_token"] = "USER_API_KEY"
        // ApiClient.apiKey["api_access_token"] = "AGENT_BOT_API_KEY"
        // ApiClient.apiKey["api_access_token"] = "PLATFORM_APP_API_KEY"

        val teamCreateUpdatePayload = TeamCreateUpdatePayload()

        try
        {
            val response = TeamsApi().createATeam(
                accountId = 0,
                _data = teamCreateUpdatePayload,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling TeamsApi#createATeam")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling TeamsApi#createATeam")
            e.printStackTrace()
        }
    }
}
