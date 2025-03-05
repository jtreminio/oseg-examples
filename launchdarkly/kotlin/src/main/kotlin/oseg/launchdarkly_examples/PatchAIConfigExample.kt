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
class PatchAIConfigExample
{
    fun patchAIConfig()
    {
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

        val aiConfigPatch = AIConfigPatch(
            description = "description",
            name = "name",
            tags = listOf (
                "tags",
                "tags",
            ),
        )

        try
        {
            val response = AIConfigsBetaApi().patchAIConfig(
                ldAPIVersion = null,
                projectKey = null,
                configKey = null,
                aiConfigPatch = aiConfigPatch,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling AIConfigsBetaApi#patchAIConfig")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling AIConfigsBetaApi#patchAIConfig")
            e.printStackTrace()
        }
    }
}
