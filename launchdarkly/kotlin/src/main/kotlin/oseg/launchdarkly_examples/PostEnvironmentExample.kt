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
class PostEnvironmentExample
{
    fun postEnvironment()
    {
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

        val environmentPost = EnvironmentPost(
            name = "My Environment",
            key = "environment-key-123abc",
            color = "DADBEE",
        )

        try
        {
            val response = EnvironmentsApi().postEnvironment(
                projectKey = null,
                environmentPost = environmentPost,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling EnvironmentsApi#postEnvironment")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling EnvironmentsApi#postEnvironment")
            e.printStackTrace()
        }
    }
}
