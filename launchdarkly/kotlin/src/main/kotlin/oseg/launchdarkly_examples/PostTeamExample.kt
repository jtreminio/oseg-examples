package oseg.launchdarkly_examples

import com.launchdarkly.client.infrastructure.*
import com.launchdarkly.client.apis.*
import com.launchdarkly.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class PostTeamExample
{
    fun postTeam()
    {
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

        val teamPostInput = TeamPostInput(
            key = "team-key-123abc",
            name = "Example team",
            description = "An example team",
            customRoleKeys = listOf (
                "example-role1",
                "example-role2",
            ),
            memberIDs = listOf (
                "12ab3c45de678910fgh12345",
            ),
        )

        try
        {
            val response = TeamsApi().postTeam(
                teamPostInput = teamPostInput,
                expand = null,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling TeamsApi#postTeam")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling TeamsApi#postTeam")
            e.printStackTrace()
        }
    }
}
