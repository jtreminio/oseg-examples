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
class SearchContextInstancesExample
{
    fun searchContextInstances()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val contextInstanceSearch = ContextInstanceSearch(
            filter = "{\"filter\": \"kindKeys:{\"contains\": [\"user:Henry\"]},\"sort\": \"-ts\",\"limit\": 50}",
            sort = "-ts",
            limit = 10,
            continuationToken = "QAGFKH1313KUGI2351",
        )

        try
        {
            val response = ContextsApi().searchContextInstances(
                projectKey = "projectKey_string",
                environmentKey = "environmentKey_string",
                contextInstanceSearch = contextInstanceSearch,
                limit = null,
                continuationToken = null,
                sort = null,
                filter = null,
                includeTotalCount = null,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ContextsApi#searchContextInstances")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ContextsApi#searchContextInstances")
            e.printStackTrace()
        }
    }
}
