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
class GetContextInstancesExample
{
    fun getContextInstances()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        try
        {
            val response = ContextsApi().getContextInstances(
                projectKey = null,
                environmentKey = null,
                id = null,
                limit = null,
                continuationToken = null,
                sort = null,
                filter = null,
                includeTotalCount = null,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ContextsApi#getContextInstances")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ContextsApi#getContextInstances")
            e.printStackTrace()
        }
    }
}
