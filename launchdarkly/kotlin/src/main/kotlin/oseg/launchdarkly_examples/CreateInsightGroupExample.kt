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
class CreateInsightGroupExample
{
    fun createInsightGroup()
    {
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

        val postInsightGroupParams = PostInsightGroupParams(
            name = "Production - All Apps",
            key = "default-production-all-apps",
            projectKey = "default",
            environmentKey = "production",
            applicationKeys = listOf (
                "billing-service",
                "inventory-service",
            ),
        )

        try
        {
            val response = InsightsScoresBetaApi().createInsightGroup(
                postInsightGroupParams = postInsightGroupParams,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling InsightsScoresBetaApi#createInsightGroup")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling InsightsScoresBetaApi#createInsightGroup")
            e.printStackTrace()
        }
    }
}
