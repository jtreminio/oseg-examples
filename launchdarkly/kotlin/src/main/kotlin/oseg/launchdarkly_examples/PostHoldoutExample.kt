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
class PostHoldoutExample
{
    fun postHoldout()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val metrics1 = MetricInput(
            key = "metric-key-123abc",
            isGroup = true,
            primary = true,
        )

        val metrics = arrayListOf<MetricInput>(
            metrics1,
        )

        val holdoutPostRequest = HoldoutPostRequest(
            name = "holdout-one-name",
            key = "holdout-key",
            description = "My holdout-one description",
            randomizationunit = "user",
            holdoutamount = "10",
            primarymetrickey = "metric-key-123abc",
            prerequisiteflagkey = "flag-key-123abc",
            attributes = listOf (
                "country",
                "device",
                "os",
            ),
            metrics = metrics,
        )

        try
        {
            val response = HoldoutsBetaApi().postHoldout(
                projectKey = "projectKey_string",
                environmentKey = "environmentKey_string",
                holdoutPostRequest = holdoutPostRequest,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling HoldoutsBetaApi#postHoldout")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling HoldoutsBetaApi#postHoldout")
            e.printStackTrace()
        }
    }
}
