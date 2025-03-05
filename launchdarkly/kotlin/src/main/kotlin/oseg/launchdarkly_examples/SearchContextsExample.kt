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
class SearchContextsExample
{
    fun searchContexts()
    {
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

        val contextSearch = ContextSearch(
            filter = "*.name startsWith Jo,kind anyOf [\"user\",\"organization\"]",
            sort = "-ts",
            limit = 10,
            continuationToken = "QAGFKH1313KUGI2351",
        )

        try
        {
            val response = ContextsApi().searchContexts(
                projectKey = null,
                environmentKey = null,
                contextSearch = contextSearch,
                limit = null,
                continuationToken = null,
                sort = null,
                filter = null,
                includeTotalCount = null,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ContextsApi#searchContexts")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ContextsApi#searchContexts")
            e.printStackTrace()
        }
    }
}
