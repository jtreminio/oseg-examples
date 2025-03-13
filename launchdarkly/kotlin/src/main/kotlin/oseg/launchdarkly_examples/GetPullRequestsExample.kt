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
class GetPullRequestsExample
{
    fun getPullRequests()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        try
        {
            val response = InsightsPullRequestsBetaApi().getPullRequests(
                projectKey = "projectKey_string",
                environmentKey = null,
                applicationKey = null,
                status = null,
                query = null,
                limit = null,
                expand = null,
                sort = null,
                from = null,
                to = null,
                after = null,
                before = null,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling InsightsPullRequestsBetaApi#getPullRequests")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling InsightsPullRequestsBetaApi#getPullRequests")
            e.printStackTrace()
        }
    }
}
