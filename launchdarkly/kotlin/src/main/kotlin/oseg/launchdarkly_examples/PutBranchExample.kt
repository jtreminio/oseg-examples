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
class PutBranchExample
{
    fun putBranch()
    {
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

        val references1Hunks1 = HunkRep(
            startingLineNumber = 45,
            lines = "var enableFeature = 'enable-feature';",
            projKey = "default",
            flagKey = "enable-feature",
            aliases = listOf (
                "enableFeature",
                "EnableFeature",
            ),
        )

        val references1Hunks = arrayListOf<HunkRep>(
            references1Hunks1,
        )

        val references1 = ReferenceRep(
            path = "/main/index.js",
            hint = "javascript",
            hunks = references1Hunks,
        )

        val references = arrayListOf<ReferenceRep>(
            references1,
        )

        val putBranch = PutBranch(
            name = "main",
            head = "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3",
            syncTime = 1706701522000,
            updateSequenceId = 25,
            commitTime = 1706701522000,
            references = references,
        )

        try
        {
            CodeReferencesApi().putBranch(
                repo = null,
                branch = null,
                putBranch = putBranch,
            )
        } catch (e: ClientException) {
            println("4xx response calling CodeReferencesApi#putBranch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling CodeReferencesApi#putBranch")
            e.printStackTrace()
        }
    }
}
