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
class PostAIConfigVariationExample
{
    fun postAIConfigVariation()
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

        val aiConfigVariationPost = AIConfigVariationPost(
            key = "key",
            name = "name",
            model = mapOf<String, Any> (),
            modelConfigKey = "modelConfigKey",
            messages = messages,
        )

        try
        {
            val response = AIConfigsBetaApi().postAIConfigVariation(
                ldAPIVersion = AIConfigsBetaApi.LdAPIVersionPostAIConfigVariation.beta,
                projectKey = "projectKey_string",
                configKey = "configKey_string",
                aiConfigVariationPost = aiConfigVariationPost,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling AIConfigsBetaApi#postAIConfigVariation")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling AIConfigsBetaApi#postAIConfigVariation")
            e.printStackTrace()
        }
    }
}
