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
class CreateDeploymentEventExample
{
    fun createDeploymentEvent()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val postDeploymentEventInput = PostDeploymentEventInput(
            projectKey = "default",
            environmentKey = "production",
            applicationKey = "billing-service",
            version = "a90a8a2",
            eventType = PostDeploymentEventInput.EventType.started,
            applicationName = "Billing Service",
            applicationKind = PostDeploymentEventInput.ApplicationKind.server,
            versionName = "v1.0.0",
            eventTime = 1706701522000,
            eventMetadata = Serializer.moshi.adapter<Map<String, Any>>().fromJson("""
                {
                    "buildSystemVersion": "v1.2.3"
                }
            """)!!,
            deploymentMetadata = Serializer.moshi.adapter<Map<String, Any>>().fromJson("""
                {
                    "buildNumber": "1234"
                }
            """)!!,
        )

        try
        {
            InsightsDeploymentsBetaApi().createDeploymentEvent(
                postDeploymentEventInput = postDeploymentEventInput,
            )
        } catch (e: ClientException) {
            println("4xx response calling InsightsDeploymentsBetaApi#createDeploymentEvent")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling InsightsDeploymentsBetaApi#createDeploymentEvent")
            e.printStackTrace()
        }
    }
}
