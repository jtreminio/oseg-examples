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
class GetAIConfigMetricsByVariationExample
{
    fun getAIConfigMetricsByVariation()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        try
        {
            val response = AIConfigsBetaApi().getAIConfigMetricsByVariation(
                ldAPIVersion = AIConfigsBetaApi.LdAPIVersionGetAIConfigMetricsByVariation.beta,
                projectKey = "projectKey_string",
                configKey = "configKey_string",
                from = 123,
                to = 456,
                env = "env_string",
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling AIConfigsBetaApi#getAIConfigMetricsByVariation")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling AIConfigsBetaApi#getAIConfigMetricsByVariation")
            e.printStackTrace()
        }
    }
}
