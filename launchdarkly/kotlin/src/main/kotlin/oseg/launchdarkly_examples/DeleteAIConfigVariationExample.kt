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
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

        try
        {
            AIConfigsBetaApi().deleteAIConfigVariation(
                ldAPIVersion = null,
                projectKey = null,
                configKey = null,
                variationKey = null,
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
