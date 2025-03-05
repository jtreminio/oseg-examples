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
class PatchExpiringTargetsExample
{
    fun patchExpiringTargets()
    {
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

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
            val response = FeatureFlagsApi().patchExpiringTargets(
                projectKey = null,
                environmentKey = null,
                featureFlagKey = null,
                patchFlagsRequest = patchFlagsRequest,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling FeatureFlagsApi#patchExpiringTargets")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling FeatureFlagsApi#patchExpiringTargets")
            e.printStackTrace()
        }
    }
}
