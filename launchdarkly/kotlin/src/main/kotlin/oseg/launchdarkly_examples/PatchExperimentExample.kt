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
class PatchExperimentExample
{
    fun patchExperiment()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val experimentPatchInput = ExperimentPatchInput(
            instructions = Serializer.moshi.adapter<List<Map<String, Any>>>().fromJson("""
                [
                    {
                        "kind": "updateName",
                        "value": "Updated experiment name"
                    }
                ]
            """)!!,
            comment = "Example comment describing the update",
        )

        try
        {
            val response = ExperimentsApi().patchExperiment(
                projectKey = null,
                environmentKey = null,
                experimentKey = null,
                experimentPatchInput = experimentPatchInput,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ExperimentsApi#patchExperiment")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ExperimentsApi#patchExperiment")
            e.printStackTrace()
        }
    }
}
