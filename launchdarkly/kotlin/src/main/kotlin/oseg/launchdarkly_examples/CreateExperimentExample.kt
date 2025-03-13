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
class CreateExperimentExample
{
    fun createExperiment()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val iterationTreatments1Parameters1 = TreatmentParameterInput(
            flagKey = "example-flag-for-experiment",
            variationId = "e432f62b-55f6-49dd-a02f-eb24acf39d05",
        )

        val iterationTreatments1Parameters = arrayListOf<TreatmentParameterInput>(
            iterationTreatments1Parameters1,
        )

        val iterationMetrics1 = MetricInput(
            key = "metric-key-123abc",
            isGroup = true,
            primary = true,
        )

        val iterationMetrics = arrayListOf<MetricInput>(
            iterationMetrics1,
        )

        val iterationTreatments1 = TreatmentInput(
            name = "Treatment 1",
            baseline = true,
            allocationPercent = "10",
            parameters = iterationTreatments1Parameters,
        )

        val iterationTreatments = arrayListOf<TreatmentInput>(
            iterationTreatments1,
        )

        val iteration = IterationInput(
            hypothesis = "Example hypothesis, the new button placement will increase conversion",
            flags = null,
            canReshuffleTraffic = true,
            primarySingleMetricKey = "metric-key-123abc",
            primaryFunnelKey = "metric-group-key-123abc",
            randomizationUnit = "user",
            attributes = listOf (
                "country",
                "device",
                "os",
            ),
            metrics = iterationMetrics,
            treatments = iterationTreatments,
        )

        val experimentPost = ExperimentPost(
            name = "Example experiment",
            key = "experiment-key-123abc",
            description = "An example experiment, used in testing",
            maintainerId = "12ab3c45de678910fgh12345",
            holdoutId = "f3b74309-d581-44e1-8a2b-bb2933b4fe40",
            iteration = iteration,
        )

        try
        {
            val response = ExperimentsApi().createExperiment(
                projectKey = null,
                environmentKey = null,
                experimentPost = experimentPost,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ExperimentsApi#createExperiment")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ExperimentsApi#createExperiment")
            e.printStackTrace()
        }
    }
}
