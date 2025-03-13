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
class GetAllReleaseProgressionsForReleasePipelineExample
{
    fun getAllReleaseProgressionsForReleasePipeline()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        try
        {
            val response = ReleasePipelinesBetaApi().getAllReleaseProgressionsForReleasePipeline(
                projectKey = "projectKey_string",
                pipelineKey = "pipelineKey_string",
                filter = null,
                limit = null,
                offset = null,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ReleasePipelinesBetaApi#getAllReleaseProgressionsForReleasePipeline")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ReleasePipelinesBetaApi#getAllReleaseProgressionsForReleasePipeline")
            e.printStackTrace()
        }
    }
}
