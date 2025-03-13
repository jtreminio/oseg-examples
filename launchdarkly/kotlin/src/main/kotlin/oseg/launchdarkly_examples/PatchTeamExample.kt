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
class PatchTeamExample
{
    fun patchTeam()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val teamPatchInput = TeamPatchInput(
            instructions = Serializer.moshi.adapter<List<Map<String, Any>>>().fromJson("""
                [
                    {
                        "kind": "updateDescription",
                        "value": "New description for the team"
                    }
                ]
            """)!!,
            comment = "Optional comment about the update",
        )

        try
        {
            val response = TeamsApi().patchTeam(
                teamKey = null,
                teamPatchInput = teamPatchInput,
                expand = null,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling TeamsApi#patchTeam")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling TeamsApi#patchTeam")
            e.printStackTrace()
        }
    }
}
