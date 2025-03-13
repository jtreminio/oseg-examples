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
class CreateIterationExample
{
    fun createIteration()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val treatments1Parameters1 = TreatmentParameterInput(
            flagKey = "example-flag-for-experiment",
            variationId = "e432f62b-55f6-49dd-a02f-eb24acf39d05",
        )

        val treatments1Parameters = arrayListOf<TreatmentParameterInput>(
            treatments1Parameters1,
        )

        val metrics1 = MetricInput(
            key = "metric-key-123abc",
            isGroup = true,
            primary = true,
        )

        val metrics = arrayListOf<MetricInput>(
            metrics1,
        )

        val treatments1 = TreatmentInput(
            name = "Treatment 1",
            baseline = true,
            allocationPercent = "10",
            parameters = treatments1Parameters,
        )

        val treatments = arrayListOf<TreatmentInput>(
            treatments1,
        )

        val iterationInput = IterationInput(
            hypothesis = "Example hypothesis, the new button placement will increase conversion",
            flags = mapOf<String, Any> (),
            canReshuffleTraffic = true,
            primarySingleMetricKey = "metric-key-123abc",
            primaryFunnelKey = "metric-group-key-123abc",
            randomizationUnit = "user",
            attributes = listOf (
                "country",
                "device",
                "os",
            ),
            metrics = metrics,
            treatments = treatments,
        )

        try
        {
            val response = ExperimentsApi().createIteration(
                projectKey = "projectKey_string",
                environmentKey = "environmentKey_string",
                experimentKey = "experimentKey_string",
                iterationInput = iterationInput,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ExperimentsApi#createIteration")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ExperimentsApi#createIteration")
            e.printStackTrace()
        }
    }
}
