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
class GetReleaseFrequencyChartExample
{
    fun getReleaseFrequencyChart()
    {
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

        try
        {
            val response = InsightsChartsBetaApi().getReleaseFrequencyChart(
                projectKey = null,
                environmentKey = null,
                applicationKey = null,
                hasExperiments = null,
                global = null,
                groupBy = null,
                from = OffsetDateTime.parse("None"),
                to = OffsetDateTime.parse("None"),
                bucketType = null,
                bucketMs = null,
                expand = null,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling InsightsChartsBetaApi#getReleaseFrequencyChart")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling InsightsChartsBetaApi#getReleaseFrequencyChart")
            e.printStackTrace()
        }
    }
}
