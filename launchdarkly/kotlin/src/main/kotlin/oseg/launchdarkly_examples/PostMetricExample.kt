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
class PostMetricExample
{
    fun postMetric()
    {
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

        val metricPost = MetricPost(
            key = "metric-key-123abc",
            kind = MetricPost.Kind.custom,
            isActive = true,
            isNumeric = false,
            eventKey = "trackedClick",
        )

        try
        {
            val response = MetricsApi().postMetric(
                projectKey = null,
                metricPost = metricPost,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling MetricsApi#postMetric")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling MetricsApi#postMetric")
            e.printStackTrace()
        }
    }
}
