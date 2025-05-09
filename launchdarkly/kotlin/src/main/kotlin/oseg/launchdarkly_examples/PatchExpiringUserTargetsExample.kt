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
class PatchExpiringUserTargetsExample
{
    fun patchExpiringUserTargets()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val patchFlagsRequest = PatchFlagsRequest(
            instructions = Serializer.moshi.adapter<List<Map<String, Any>>>().fromJson("""
                [
                    {
                        "kind": "addExpireUserTargetDate",
                        "userKey": "sandy",
                        "value": 1686412800000,
                        "variationId": "ce12d345-a1b2-4fb5-a123-ab123d4d5f5d"
                    }
                ]
            """)!!,
            comment = "optional comment",
        )

        try
        {
            val response = FeatureFlagsApi().patchExpiringUserTargets(
                projectKey = "projectKey_string",
                environmentKey = "environmentKey_string",
                featureFlagKey = "featureFlagKey_string",
                patchFlagsRequest = patchFlagsRequest,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling FeatureFlagsApi#patchExpiringUserTargets")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling FeatureFlagsApi#patchExpiringUserTargets")
            e.printStackTrace()
        }
    }
}
