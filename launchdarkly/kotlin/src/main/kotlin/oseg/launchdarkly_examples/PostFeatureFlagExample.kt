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
class PostFeatureFlagExample
{
    fun postFeatureFlag()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val clientSideAvailability = ClientSideAvailabilityPost(
            usingEnvironmentId = true,
            usingMobileKey = true,
        )

        val featureFlagBody = FeatureFlagBody(
            name = "My Flag",
            key = "flag-key-123abc",
            clientSideAvailability = clientSideAvailability,
        )

        try
        {
            val response = FeatureFlagsApi().postFeatureFlag(
                projectKey = "projectKey_string",
                featureFlagBody = featureFlagBody,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling FeatureFlagsApi#postFeatureFlag")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling FeatureFlagsApi#postFeatureFlag")
            e.printStackTrace()
        }
    }
}
