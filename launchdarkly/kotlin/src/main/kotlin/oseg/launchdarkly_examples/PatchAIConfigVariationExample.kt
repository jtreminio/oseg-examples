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
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

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

        val aIConfigVariationPatch = AIConfigVariationPatch(
            modelConfigKey = "modelConfigKey",
            name = "name",
            published = true,
            messages = messages,
        )

        try
        {
            val response = AIConfigsBetaApi().patchAIConfigVariation(
                lDAPIVersion = null,
                projectKey = null,
                configKey = null,
                variationKey = null,
                aIConfigVariationPatch = aIConfigVariationPatch,
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
