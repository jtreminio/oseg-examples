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
class PostModelConfigExample
{
    fun postModelConfig()
    {
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

        val modelConfigPost = ModelConfigPost(
            id = "id",
            key = "key",
            name = "name",
            icon = "icon",
            provider = "provider",
            tags = listOf (
                "tags",
                "tags",
            ),
            params = Map.of (),
            customParams = Map.of (),
        )

        try
        {
            val response = AIConfigsBetaApi().postModelConfig(
                ldAPIVersion = null,
                projectKey = "default",
                modelConfigPost = modelConfigPost,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling AIConfigsBetaApi#postModelConfig")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling AIConfigsBetaApi#postModelConfig")
            e.printStackTrace()
        }
    }
}
