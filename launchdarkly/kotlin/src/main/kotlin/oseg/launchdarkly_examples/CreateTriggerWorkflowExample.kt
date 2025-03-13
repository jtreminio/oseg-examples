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
class CreateTriggerWorkflowExample
{
    fun createTriggerWorkflow()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val triggerPost = TriggerPost(
            integrationKey = "generic-trigger",
            comment = "example comment",
            instructions = Serializer.moshi.adapter<List<Map<String, Any>>>().fromJson("""
                [
                    {
                        "kind": "turnFlagOn"
                    }
                ]
            """)!!,
        )

        try
        {
            val response = FlagTriggersApi().createTriggerWorkflow(
                projectKey = null,
                environmentKey = null,
                featureFlagKey = null,
                triggerPost = triggerPost,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling FlagTriggersApi#createTriggerWorkflow")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling FlagTriggersApi#createTriggerWorkflow")
            e.printStackTrace()
        }
    }
}
