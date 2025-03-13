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
class CreateMetricGroupExample
{
    fun createMetricGroup()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val metrics1 = MetricInMetricGroupInput(
            key = "metric-key-123abc",
            nameInGroup = "Step 1",
        )

        val metrics = arrayListOf<MetricInMetricGroupInput>(
            metrics1,
        )

        val metricGroupPost = MetricGroupPost(
            key = "metric-group-key-123abc",
            name = "My metric group",
            kind = MetricGroupPost.Kind.funnel,
            maintainerId = "569fdeadbeef1644facecafe",
            tags = listOf (
                "ops",
            ),
            description = "Description of the metric group",
            metrics = metrics,
        )

        try
        {
            val response = MetricsBetaApi().createMetricGroup(
                projectKey = "projectKey_string",
                metricGroupPost = metricGroupPost,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling MetricsBetaApi#createMetricGroup")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling MetricsBetaApi#createMetricGroup")
            e.printStackTrace()
        }
    }
}
