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
class GetFlagEventsExample
{
    fun getFlagEvents()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        try
        {
            val response = InsightsFlagEventsBetaApi().getFlagEvents(
                projectKey = "projectKey_string",
                environmentKey = "environmentKey_string",
                applicationKey = null,
                query = null,
                impactSize = null,
                hasExperiments = null,
                global = null,
                expand = null,
                limit = null,
                from = null,
                to = null,
                after = null,
                before = null,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling InsightsFlagEventsBetaApi#getFlagEvents")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling InsightsFlagEventsBetaApi#getFlagEvents")
            e.printStackTrace()
        }
    }
}
