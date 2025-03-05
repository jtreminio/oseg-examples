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
class PatchFlagConfigScheduledChangeExample
{
    fun patchFlagConfigScheduledChange()
    {
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

        val flagScheduledChangesInput = FlagScheduledChangesInput(
            instructions = Serializer.moshi.adapter<List<Map<String, Any>>>().fromJson("""
                [
                    {
                        "kind": "replaceScheduledChangesInstructions",
                        "value": [
                            {
                                "kind": "turnFlagOff"
                            }
                        ]
                    }
                ]
            """)!!,
            comment = "Optional comment describing the update to the scheduled changes",
        )

        try
        {
            val response = ScheduledChangesApi().patchFlagConfigScheduledChange(
                projectKey = null,
                featureFlagKey = null,
                environmentKey = null,
                id = null,
                flagScheduledChangesInput = flagScheduledChangesInput,
                ignoreConflicts = null,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ScheduledChangesApi#patchFlagConfigScheduledChange")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ScheduledChangesApi#patchFlagConfigScheduledChange")
            e.printStackTrace()
        }
    }
}
