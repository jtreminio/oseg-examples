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
class PostFlagConfigScheduledChangesExample
{
    fun postFlagConfigScheduledChanges()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val postFlagScheduledChangesInput = PostFlagScheduledChangesInput(
            executionDate = 1718467200000,
            instructions = Serializer.moshi.adapter<List<Map<String, Any>>>().fromJson("""
                [
                    {
                        "kind": "turnFlagOn"
                    }
                ]
            """)!!,
            comment = "Optional comment describing the scheduled changes",
        )

        try
        {
            val response = ScheduledChangesApi().postFlagConfigScheduledChanges(
                projectKey = "projectKey_string",
                featureFlagKey = "featureFlagKey_string",
                environmentKey = "environmentKey_string",
                postFlagScheduledChangesInput = postFlagScheduledChangesInput,
                ignoreConflicts = null,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ScheduledChangesApi#postFlagConfigScheduledChanges")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ScheduledChangesApi#postFlagConfigScheduledChanges")
            e.printStackTrace()
        }
    }
}
