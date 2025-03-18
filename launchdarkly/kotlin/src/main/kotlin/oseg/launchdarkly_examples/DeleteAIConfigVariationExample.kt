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
class DeleteAIConfigVariationExample
{
    fun deleteAIConfigVariation()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        try
        {
            AIConfigsBetaApi().deleteAIConfigVariation(
                ldAPIVersion = AIConfigsBetaApi.LdAPIVersionDeleteAIConfigVariation.beta,
                projectKey = "projectKey_string",
                configKey = "configKey_string",
                variationKey = "variationKey_string",
            )
        } catch (e: ClientException) {
            println("4xx response calling AIConfigsBetaApi#deleteAIConfigVariation")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling AIConfigsBetaApi#deleteAIConfigVariation")
            e.printStackTrace()
        }
    }
}
