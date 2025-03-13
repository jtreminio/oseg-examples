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
class PatchAIConfigVariationExample
{
    fun patchAIConfigVariation()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val messages1 = Message(
            content = "content",
            role = "role",
        )

        val messages2 = Message(
            content = "content",
            role = "role",
        )

        val messages = arrayListOf<Message>(
            messages1,
            messages2,
        )

        val aiConfigVariationPatch = AIConfigVariationPatch(
            modelConfigKey = "modelConfigKey",
            name = "name",
            published = true,
            model = mapOf<String, Any> (),
            messages = messages,
        )

        try
        {
            val response = AIConfigsBetaApi().patchAIConfigVariation(
                ldAPIVersion = AIConfigsBetaApi.LdAPIVersionPatchAIConfigVariation.beta,
                projectKey = "projectKey_string",
                configKey = "configKey_string",
                variationKey = "variationKey_string",
                aiConfigVariationPatch = aiConfigVariationPatch,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling AIConfigsBetaApi#patchAIConfigVariation")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling AIConfigsBetaApi#patchAIConfigVariation")
            e.printStackTrace()
        }
    }
}
