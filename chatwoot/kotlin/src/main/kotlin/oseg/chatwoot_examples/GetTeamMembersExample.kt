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
class GetTeamMembersExample
{
    fun getTeamMembers()
    {
        ApiClient.apiKey["api_access_token"] = "USER_API_KEY"

        try
        {
            val response = TeamsApi().getTeamMembers(
                accountId = 0,
                teamId = 0,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling TeamsApi#getTeamMembers")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling TeamsApi#getTeamMembers")
            e.printStackTrace()
        }
    }
}
