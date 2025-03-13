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
class DeleteReleasePipelineExample
{
    fun deleteReleasePipeline()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        try
        {
            ReleasePipelinesBetaApi().deleteReleasePipeline(
                projectKey = "projectKey_string",
                pipelineKey = "pipelineKey_string",
            )
        } catch (e: ClientException) {
            println("4xx response calling ReleasePipelinesBetaApi#deleteReleasePipeline")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ReleasePipelinesBetaApi#deleteReleasePipeline")
            e.printStackTrace()
        }
    }
}
