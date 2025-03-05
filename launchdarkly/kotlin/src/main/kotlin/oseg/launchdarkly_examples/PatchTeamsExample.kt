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
class PatchTeamsExample
{
    fun patchTeams()
    {
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

        val teamsPatchInput = TeamsPatchInput(
            instructions = Serializer.moshi.adapter<List<Map<String, Any>>>().fromJson("""
                [
                    {
                        "kind": "addMembersToTeams",
                        "memberIDs": [
                            "1234a56b7c89d012345e678f"
                        ],
                        "teamKeys": [
                            "example-team-1",
                            "example-team-2"
                        ]
                    }
                ]
            """)!!,
            comment = "Optional comment about the update",
        )

        try
        {
            val response = TeamsBetaApi().patchTeams(
                teamsPatchInput = teamsPatchInput,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling TeamsBetaApi#patchTeams")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling TeamsBetaApi#patchTeams")
            e.printStackTrace()
        }
    }
}
