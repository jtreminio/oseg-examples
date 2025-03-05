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
class CreateIntegrationDeliveryConfigurationExample
{
    fun createIntegrationDeliveryConfiguration()
    {
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

        val integrationDeliveryConfigurationPost = IntegrationDeliveryConfigurationPost(
            config = Serializer.moshi.adapter<Map<String, Any>>().fromJson("""
                {
                    "optional": "example value for optional formVariables property for sample-integration",
                    "required": "example value for required formVariables property for sample-integration"
                }
            """)!!,
            on = false,
            name = "Sample integration",
            tags = listOf (
                "example-tag",
            ),
        )

        try
        {
            val response = IntegrationDeliveryConfigurationsBetaApi().createIntegrationDeliveryConfiguration(
                projectKey = null,
                environmentKey = null,
                integrationKey = null,
                integrationDeliveryConfigurationPost = integrationDeliveryConfigurationPost,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling IntegrationDeliveryConfigurationsBetaApi#createIntegrationDeliveryConfiguration")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling IntegrationDeliveryConfigurationsBetaApi#createIntegrationDeliveryConfiguration")
            e.printStackTrace()
        }
    }
}
