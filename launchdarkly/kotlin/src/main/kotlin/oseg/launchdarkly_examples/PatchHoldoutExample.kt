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
class PatchHoldoutExample
{
    fun patchHoldout()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val holdoutPatchInput = HoldoutPatchInput(
            instructions = Serializer.moshi.adapter<List<Map<String, Any>>>().fromJson("""
                [
                    {
                        "kind": "updateName",
                        "value": "Updated holdout name"
                    }
                ]
            """)!!,
            comment = "Optional comment describing the update",
        )

        try
        {
            val response = HoldoutsBetaApi().patchHoldout(
                projectKey = "projectKey_string",
                environmentKey = "environmentKey_string",
                holdoutKey = "holdoutKey_string",
                holdoutPatchInput = holdoutPatchInput,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling HoldoutsBetaApi#patchHoldout")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling HoldoutsBetaApi#patchHoldout")
            e.printStackTrace()
        }
    }
}
