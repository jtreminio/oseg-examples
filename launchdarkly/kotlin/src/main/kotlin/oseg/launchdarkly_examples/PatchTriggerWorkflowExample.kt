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
class PatchTriggerWorkflowExample
{
    fun patchTriggerWorkflow()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val flagTriggerInput = FlagTriggerInput(
            comment = "optional comment",
            instructions = Serializer.moshi.adapter<List<Map<String, Any>>>().fromJson("""
                [
                    {
                        "kind": "disableTrigger"
                    }
                ]
            """)!!,
        )

        try
        {
            val response = FlagTriggersApi().patchTriggerWorkflow(
                projectKey = null,
                environmentKey = null,
                featureFlagKey = null,
                id = null,
                flagTriggerInput = flagTriggerInput,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling FlagTriggersApi#patchTriggerWorkflow")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling FlagTriggersApi#patchTriggerWorkflow")
            e.printStackTrace()
        }
    }
}
