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
class PostAIConfigExample
{
    fun postAIConfig()
    {
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

        val aiConfigPost = AIConfigPost(
            key = "key",
            name = "name",
            description = "",
            tags = listOf (
                "tags",
                "tags",
            ),
        )

        try
        {
            val response = AIConfigsBetaApi().postAIConfig(
                ldAPIVersion = null,
                projectKey = null,
                aiConfigPost = aiConfigPost,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling AIConfigsBetaApi#postAIConfig")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling AIConfigsBetaApi#postAIConfig")
            e.printStackTrace()
        }
    }
}
