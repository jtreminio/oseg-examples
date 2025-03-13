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
class CopyFeatureFlagExample
{
    fun copyFeatureFlag()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val source = FlagCopyConfigEnvironment(
            key = "source-env-key-123abc",
            currentVersion = 1,
        )

        val target = FlagCopyConfigEnvironment(
            key = "target-env-key-123abc",
            currentVersion = 1,
        )

        val flagCopyConfigPost = FlagCopyConfigPost(
            comment = "optional comment",
            source = source,
            target = target,
        )

        try
        {
            val response = FeatureFlagsApi().copyFeatureFlag(
                projectKey = "projectKey_string",
                featureFlagKey = "featureFlagKey_string",
                flagCopyConfigPost = flagCopyConfigPost,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling FeatureFlagsApi#copyFeatureFlag")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling FeatureFlagsApi#copyFeatureFlag")
            e.printStackTrace()
        }
    }
}
